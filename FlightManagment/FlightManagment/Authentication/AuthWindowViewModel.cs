using FlightManagement.Base.Authentication;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FlightManagement.Authentication
{
    public class AuthWindowViewModel : INotifyPropertyChanged
    {
        private string _login;
        private string _password;
        private ICommand _loginCommand;
        public event PropertyChangedEventHandler? PropertyChanged;

        public string Login
        {
            get => _login;
            set
            {
                if (value == _login) return;
                _login = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand
        {
            get => _loginCommand;
            set
            {
                if (Equals(value, _loginCommand)) return;
                _loginCommand = value;
                OnPropertyChanged();
            }
        }

        public AuthWindowViewModel(AccountDataProvider accountDataProvider)
        {
            _loginCommand = new LoginCommand(accountDataProvider);
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
