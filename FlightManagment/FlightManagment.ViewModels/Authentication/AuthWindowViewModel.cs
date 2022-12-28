using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FlightManagement.Base.Authentication;

namespace FlightManagement.ViewModels.Authentication
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

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
