namespace FlightManagement.Data.Models;

public partial class Flight
{
    public int FliId { get; set; }

    public string FliStartAirport { get; set; } = null!;

    public string FliEndAirport { get; set; } = null!;

    public string FliStartPlace { get; set; } = null!;

    public string FliEndPlace { get; set; } = null!;

    public int FliFlightLength { get; set; }

    public DateTime FliStartDate { get; set; }

    public int? AipId { get; set; }

    public int FliSoldTickets { get; set; }

    public int FliSoldCargo { get; set; }

    public int? CrwId { get; set; }

    public int? FliTicketPrice { get; set; }

    public virtual AirPlane? Aip { get; set; }

    public virtual ICollection<CrewToFlightAssoc> CrewToFlightAssocs { get; } = new List<CrewToFlightAssoc>();

    public virtual CrewMember? Crw { get; set; }
}
