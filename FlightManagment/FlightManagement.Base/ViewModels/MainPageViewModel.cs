using FlightManagement.Base.ViewModels.Airplane;

namespace FlightManagement.Base.ViewModels;

public class MainPageViewModel
{
    public AirPlanesListViewModel AirPlanesListViewModel { get; set; }
    public Crew.CrewViewModel CrewViewModel { get; set; }
}