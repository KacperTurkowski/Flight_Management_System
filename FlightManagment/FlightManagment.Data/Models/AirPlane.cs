namespace FlightManagement.Data.Models;

public partial class AirPlane
{
    public int AipId { get; set; }

    public string AipName { get; set; } = null!;

    public string AipProducer { get; set; } = null!;

    public bool AipIsNarrowBody { get; set; }

    public int AipMaxWeight { get; set; }

    public int AipMaxPassengers { get; set; }

    public int AipFuelUsage { get; set; }

    public virtual ICollection<Flight> Flights { get; } = new List<Flight>();
}
