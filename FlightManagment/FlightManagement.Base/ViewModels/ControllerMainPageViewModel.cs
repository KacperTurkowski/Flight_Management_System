using FlightManagement.Base.ViewModels.Flights;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FlightManagement.Base.ViewModels
{
    public class ControllerMainPageViewModel : IFlightCollection
    {
        public ObservableCollection<FlightViewModel> Flights { get; set; }
        public int SwitchView { get; set; } = 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
