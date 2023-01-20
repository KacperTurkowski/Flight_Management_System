using System.Windows.Input;

namespace FlightManagement.Base.ViewModels.Airplane;

public class AirplaneViewModel
{
    private int _maxWeight;
    private int _maxPassengers;
    private int _fuelUsage;
    public int AirplaneId { get; set; }
    public string Name { get; set; }
    public string Producer { get; set; }
    public bool IsNarrowBody { get; set; }

    public string NarrowBodyName => IsNarrowBody ? "Wąskokadłubowy" : "Szerokokiadłubowy";

    public int MaxWeight
    {
        get => _maxWeight;
        set
        {
            if (value < 0)
                throw new ArgumentException();
            _maxWeight = value;
        }
    }

    public int MaxPassengers
    {
        get => _maxPassengers;
        set
        {
            if (value < 0)
                throw new ArgumentException();
            _maxPassengers = value;
        }
    }

    public int FuelUsage
    {
        get => _fuelUsage;
        set
        {
            if (value < 0)
                throw new ArgumentException();
            _fuelUsage = value;
        }
    }

    public ICommand DeleteAirplaneCommand { get; set; }
}