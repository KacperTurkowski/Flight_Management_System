using FlightManagement.AirPlanesPage.AirplaneInfo;
using System.Windows.Input;

namespace FlightManagement.AirPlanesPage;

public class AirplaneViewModel
{
    public string Name { get; set; }
    public string Producer { get; set; }
    public bool IsNarrowBody { get; set; }

    public string NarrowBodyName => IsNarrowBody ? "Wąskokadłubowy" : "Szerokokiadłubowy";
    public int MaxWeight { get; set; }
    public int MaxPassengers { get; set; }
    public int FuelUsage { get; set; }
    public ICommand DeleteAirplaneCommand { get; } = new DeleteAirplaneCommand();
}