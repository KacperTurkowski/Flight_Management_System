using System;
using System.Windows;
using System.Windows.Input;
using FlightManagement.Base.Authentication;
using FlightManagement.ViewModels.Authentication;

namespace FlightManagement.Authentication
{
    public class LoginCommand : ICommand
    {
        private readonly AccountDataProvider _accountDataProvider;

        public LoginCommand(AccountDataProvider accountDataProvider)
        {
            _accountDataProvider = accountDataProvider;
        }
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is not Window authWindow || authWindow.DataContext is not AuthWindowViewModel authWindowViewModel) throw new ArgumentNullException(nameof(parameter));

            //TODO verify data

            authWindow.DialogResult = true;
            authWindow.Close();
            
            _accountDataProvider.Login = authWindowViewModel.Login;

        }

        public event EventHandler? CanExecuteChanged { add{} remove{} }
    }
}
