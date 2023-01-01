using System.Collections.ObjectModel;
using System.Windows.Input;
using FlightManagement.Base.Position;

namespace FlightManagement.Base.ViewModels.Crew;

public class CrewMemberViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ObservableCollection<string> Positions { get; set; }
    public string Position { get; set; }
    public PositionEnum PositionEnum => PositionToStringMapper.MapTo(Position);
    public int SocialSecurityNumber { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public int PhoneNumber { get; set; }
    public string Email { get; set; }
    public ICommand CloseAddCrewMemberCommand { get; set; }
    public ICommand DeleteCrewMemberCommand { get; set; }

    public string NameWithPosition => string.Concat(Position, ": ", FirstName, " ", LastName);
    public string FullName => string.Concat(FirstName, " ", LastName);
    public string FullAddress => string.Concat(Street, " ", HouseNumber, ", ", PostalCode, " ", City);

    public CrewMemberViewModel()
    {
        Positions = GetPositionsString();
    }

    public static ObservableCollection<string> GetPositionsString()
    {
        var values = Enum.GetValues(typeof(PositionEnum)).Cast<PositionEnum>().Except(new[] { PositionEnum.Admin }).ToList();
        var result = new ObservableCollection<string>();

        foreach (var positionEnum in values)
            result.Add(PositionToStringMapper.MapTo(positionEnum));

        return result;
    }
}