
namespace ShareAndCare.ViewModels
{
    using GalaSoft.MvvmLight.Views;
    using Microsoft.EntityFrameworkCore;
    using ShareAndCare.Commands;
    using ShareAndCare.DataContext;
    using ShareAndCare.Models;
    using ShareAndCare.Views;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    internal class UserViewModel : DefaultViewMode, IDataErrorInfo
    {
        private User user;
        private ApplicationViewModel applicationViewModel;

        public UserViewModel()
        {
            user = new User();
            LoginCommand = new UserLoginCommand(this);
        }

        public string this[string columnName]
        {
            get
            {
                Error = null;
                if (columnName == "Username" || columnName == "Pass")
                    if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Pass))
                    {
                        Error = "Username and Password is a must!";
                    }
                return Error;
            }
        }

        public string Username
        {
            get
            {
                return user.Username;
            }
            set
            {
                user.Username = value;
            }
        }

        public string Pass
        {
            get
            {
                return user.Password.Secret;
            }
            set
            {
                user.Password.Secret = value;
            }
        }

        public ICommand LoginCommand
        {
            get;
            private set;
        }

        public string Error { get; private set; }

        public void LoginUser(object parameter)
        {
            var cont = new TheContext();

            var existingUser = cont.Users.Where(s => s.Username == user.Username).SingleOrDefault<User>();
            if (existingUser == null)
            {
                cont.Add(user);
                cont.SaveChanges();
                
                existingUser = cont.Users.Where(s => s.Username == user.Username).SingleOrDefault<User>();
            }
            //.Include(c => c.Password)
            cont.Passwords.Attach(cont.Passwords.Where(a => a.User == existingUser).SingleOrDefault());
            cont.Dispose();
            if (Pass == existingUser.Password.Secret)
            {
                if (parameter is System.Windows.Window)
                {
                    ApplicationWindow view = new ApplicationWindow();
                    applicationViewModel = new ApplicationViewModel(existingUser);

                    view.DataContext = applicationViewModel;
                    view.Show();

                    (parameter as System.Windows.Window).Close();
                }
            }
            else
            {
                Username = "";
                Pass = "";
                OnPropertyChanged("Username");
                OnPropertyChanged("Pass");
            }
        }
            

        }

 }
