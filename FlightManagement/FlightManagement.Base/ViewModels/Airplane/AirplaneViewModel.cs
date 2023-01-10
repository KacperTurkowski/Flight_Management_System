using System.Windows.Input;

namespace FlightManagement.Base.ViewModels.Airplane;

public class AirplaneViewModel
{
    public int AirplaneId { get; set; }
    public string Name { get; set; }
    public string Producer { get; set; }
    public bool IsNarrowBody { get; set; }

    public string NarrowBodyName => IsNarrowBody ? "Wąskokadłubowy" : "Szerokokiadłubowy";
    public int MaxWeight { get; set; }
    public int MaxPassengers { get; set; }
    public int FuelUsage { get; set; }
    public ICommand DeleteAirplaneCommand { get; set; }
}