using ShareAndCare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShareAndCare.Commands
{
    internal class UserLoginCommand : ICommand
    {
        private UserViewModel _ViewModel;
        public UserLoginCommand(UserViewModel viewModel)
        {
            _ViewModel = viewModel;
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return string.IsNullOrWhiteSpace(_ViewModel.Error);
        }

        public void Execute(object parameter)
        {
            _ViewModel.LoginUser(parameter);
        }
    }
}
