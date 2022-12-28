using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FlightManagement.ViewModels.AirPlanesPage
{
    public class AirPlanesListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Airplane> _airplanes;
        private ICommand _addPlaneCommand;

        public ICommand AddPlaneCommand
        {
            get => _addPlaneCommand;
            set
            {
                if (Equals(value, _addPlaneCommand)) return;
                _addPlaneCommand = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Airplane> Airplanes
        {
            get => _airplanes;
            set
            {
                if (Equals(value, _airplanes)) return;
                _airplanes = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
