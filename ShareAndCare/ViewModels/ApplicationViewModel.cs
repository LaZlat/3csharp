
namespace ShareAndCare.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Microsoft.Win32;
    using ShareAndCare.Commands;
    using ShareAndCare.DataContext;
    using ShareAndCare.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    internal class ApplicationViewModel : DefaultViewMode, IDataErrorInfo
    {
        private User user;
        private File file = new File();

        public ApplicationViewModel(User _user)
        {
            user = _user;
            ChooseCommand = new DelegateCommand(ChooseFile);
            AddCommand = new ApplicationAddCommand(this);
            SendCommand = new ApplicationSendCommand(this);
            LogOffCommand = new DelegateCommand(LogOff);
        }

        public string Message { get; set; } = "";

        public string FileName
        {
            get
            {
                return file.FileName;
            }
            set
            {
                file.FileName = value;
            }
        }

        public string FilePath
        {
            get
            {
                return file.FilePath;
            }
            set
            {
                file.FilePath = value;
            }
        }

        public ObservableCollection<File> Files
        {
            get
            {
                var cont = new TheContext();

                var smth = cont.Users.Where(a => a.Username == user.Username).Select(a => a.Files).SingleOrDefault();
   
                ObservableCollection < File > newOne = new ObservableCollection<File>(smth);
                cont.Dispose();

                return newOne;
            }
        }

        public ObservableCollection<User> People
        {
            get
            {
                ObservableCollection<User> newOne;
                using (var cont = new TheContext())
                {
                    var smth = cont.Users.Where(a => a.Username == user.Username).SelectMany(a => a.Friends);
                    var qq = smth.Select(x => x.FriendId).ToList();
                    var xx = cont.Users.Where(p => !qq.Contains(p.Id)).ToList();
                    newOne = new ObservableCollection<User>(xx);
                }

                return newOne;
            }
        }

        public ObservableCollection<string> Msg
        {
            get
            {
                ObservableCollection<string> newOne;
                using (var cont = new TheContext()) 
                {
                    var smth = cont.Messages.Select(a => a.Msg).ToList();
                    newOne = new ObservableCollection<string>(smth);
                }

                return newOne;
            }
        }

        public ObservableCollection<File> Friends
        {
            get
            {
                ObservableCollection<File> newOne = new ObservableCollection<File>();
                //using (var cont = new TheContext())
               // {
                    //var smth = cont.Friends.SelectMany(a => a.Files).ToList();
                   // newOne = new ObservableCollection<File>(smth);
                //}

                return newOne;
            }
        }

        public string Username
        {
            get
            {
                return user.Username;
            }
        }

        public ICommand ChooseCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand SendCommand { get; private set; }
        public ICommand LogOffCommand { get; private set; }


        public void AddFileToList()
        {
            var cont = new TheContext();

            user.Files.Add(new File { FileName = file.FileName , FilePath = file.FilePath });
            cont.Users.Update(user);

            cont.SaveChanges();
            cont.Dispose();
                
            OnPropertyChanged("Files");
            //OnPropertyChanged("FilePath");
        }

        public void ChooseFile(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                FileName = openFileDialog.SafeFileName;
                OnPropertyChanged("FilePath");
            }
        }


        public void SendMessage()
        {
            var cont = new TheContext();

            user.Msg.Add(new Message { Msg = user.Username + ": " + Message });
            cont.Users.Update(user);

            cont.SaveChanges();
            cont.Dispose();

            OnPropertyChanged("Msg");
            Message = "";
            OnPropertyChanged("Message");
        }

        public void LogOff(object parameter)
        {
            if (parameter is System.Windows.Window)
            {
                MainWindow view = new MainWindow();
                view.DataContext = new UserViewModel();
                view.Show();
                (parameter as System.Windows.Window).Close();
            }
        }

        private RelayCommand<File> _deleteCommand;
        public RelayCommand<File> DeleCommand
        {
            get
            {
                return _deleteCommand
                  ?? (_deleteCommand = new RelayCommand<File>(
                    _file =>
                    {
                        using (var cont = new TheContext())
                        {
                            cont.Files.Remove(_file);
                            cont.SaveChanges();
                        }

                        OnPropertyChanged("Files");
                    }));
            }
        }

        private RelayCommand<User> _addFriendCommand;
        public RelayCommand<User> AddFriendCommand
        {
            get
            {
                return _addFriendCommand
                  ?? (_addFriendCommand = new RelayCommand<User>(
                    _friend =>
                    {
                        using (var cont = new TheContext())
                        {
                            //user.Friends.Add(new Friend { Files = _friend.Files });
                            cont.Users.Update(user);
                            cont.SaveChanges();
                        }
                        OnPropertyChanged("Friends");
                    }));
            }
        }
        public string Error { get; private set; }

        public string this[string columnName]
        {
            get
            {
                Error = null;
                switch (columnName)
                {
                    case "Message": if (string.IsNullOrWhiteSpace(Message)) Error = "You can't spam with empty messages"; break;
                    case "FilePath": if (string.IsNullOrWhiteSpace(FilePath)) Error = "Must provide file path"; break;
                }
                return Error;
            }
        }
    }
}
