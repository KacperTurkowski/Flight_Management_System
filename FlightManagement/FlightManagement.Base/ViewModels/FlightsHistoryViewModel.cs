using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FlightManagement.Base.ViewModels.Flights;

namespace FlightManagement.Base.ViewModels
{
    public class FlightsHistoryViewModel :  IFlightCollection
    {
        public ObservableCollection<FlightViewModel> Flights { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
