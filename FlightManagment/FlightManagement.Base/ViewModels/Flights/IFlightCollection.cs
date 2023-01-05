using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FlightManagement.Base.ViewModels.Flights;

public interface IFlightCollection : INotifyPropertyChanged
{
    public ObservableCollection<FlightViewModel> Flights { get; set; }
    public void OnPropertyChanged([CallerMemberName] string? propertyName = null);

}