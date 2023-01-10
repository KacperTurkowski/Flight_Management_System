namespace FlightManagement.Data.Models;

public partial class CrewToFlightAssoc
{
    public int CtfId { get; set; }

    public int FliId { get; set; }

    public int CrwId { get; set; }

    public virtual CrewMember Crw { get; set; } = null!;

    public virtual Flight Fli { get; set; } = null!;
}
