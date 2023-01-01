using System;
using System.Windows;
using System.Windows.Input;
using FlightManagement.Base.Authentication;
using FlightManagement.Base.Position;
using FlightManagement.Base.ViewModels.Authorization;

namespace FlightManagement.Authentication
{
    public class LoginCommand : ICommand
    {
        private readonly AccountDataProvider _accountDataProvider;
        private readonly AccountVerifier _accountVerifier;

        public LoginCommand(AccountDataProvider accountDataProvider)
        {
            _accountDataProvider = accountDataProvider;
            _accountVerifier = new AccountVerifier();
        }
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is not AuthWindow authWindow || authWindow.DataContext is not AuthWindowViewModel authWindowViewModel) throw new ArgumentNullException(nameof(parameter));

            var account = _accountVerifier.Verify(authWindowViewModel.Login, authWindow.PasswordBox.Password);

            if (account == null)
            {
                MessageBox.Show(authWindow, "Błędny login lub hasło", "Błąd", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            authWindow.DialogResult = true;
            authWindow.Close();
            
            _accountDataProvider.Login = authWindowViewModel.Login;
            if(account.CrwPosition == PositionEnum.Admin.ToString())
                _accountDataProvider.Position = PositionEnum.Admin;
            else if (account.CrwPosition == PositionEnum.Controller.ToString())
                _accountDataProvider.Position = PositionEnum.Controller;
            else
                throw new InvalidOperationException();
        }

        public event EventHandler? CanExecuteChanged { add{} remove{} }
    }
}
