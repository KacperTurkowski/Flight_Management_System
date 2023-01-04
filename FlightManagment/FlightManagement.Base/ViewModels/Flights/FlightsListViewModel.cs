using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FlightManagement.Base.Authentication;

namespace FlightManagement.Base.ViewModels.Flights
{
    public class FlightsListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<FlightViewModel> Flights { get; set; }
        public ICommand AddFlightCommand { get; set; }
        public AccountDataProvider AccountDataProvider { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
