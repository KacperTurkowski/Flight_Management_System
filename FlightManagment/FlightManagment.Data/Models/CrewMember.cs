namespace FlightManagement.Data.Models;

public partial class CrewMember
{
    public int CrwId { get; set; }

    public string CrwFirstName { get; set; } = null!;

    public string CrwLastName { get; set; } = null!;

    public string CrwPosition { get; set; } = null!;

    public int CrwSocialSecurityNumber { get; set; }

    public string CrwStreet { get; set; } = null!;

    public string CrwHouseNumber { get; set; } = null!;

    public string CrwPostalCode { get; set; } = null!;

    public string CrwCity { get; set; } = null!;

    public int CrwPhoneNumber { get; set; }

    public string CrwEmail { get; set; } = null!;

    public string? CrwPassword { get; set; }
}
