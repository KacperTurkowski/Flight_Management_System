using FlightManagement.Base.ViewModels.Airplane;
using FlightManagement.Base.ViewModels.Flights;

namespace FlightManagement.Base.ViewModels;

public class MainPageViewModel
{
    public AirPlanesListViewModel AirPlanesListViewModel { get; set; }
    public Crew.CrewViewModel CrewViewModel { get; set; }
    public FlightsListViewModel FlightsListViewModel { get; set; }
    public int SwitchView { get; set; } = 1;
    public FlightsHistoryViewModel FlightsHistoryViewModel { get; set; }
}