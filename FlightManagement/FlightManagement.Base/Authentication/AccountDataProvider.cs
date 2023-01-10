using FlightManagement.Base.Position;

namespace FlightManagement.Base.Authentication;

public class AccountDataProvider
{
    public string Login { get; set; }
    public PositionEnum Position { get; set; }
}