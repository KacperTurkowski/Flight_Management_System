using FlightManagement.Base.ViewModels.Flights;
using System.Collections.ObjectModel;

namespace FlightManagement.Base.ViewModels
{
    public class ControllerMainPageViewModel
    {
        public ObservableCollection<FlightViewModel> Flights { get; set; }
        public int SwitchView { get; set; } = 0;

    }
}
