using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FlightManagement.Base.Position;

namespace FlightManagement.Base.ViewModels.Crew;

public class CrewMemberViewModel : INotifyPropertyChanged
{
    private int _socialSecurityNumber;
    private int _phoneNumber;
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ObservableCollection<string> Positions { get; set; }
    public string Position { get; set; }
    public PositionEnum PositionEnum => PositionToStringMapper.MapTo(Position);

    public int SocialSecurityNumber
    {
        get => _socialSecurityNumber;
        set
        {
            if (value < 0)
            {
                OnPropertyChanged();
                return;
            }
            _socialSecurityNumber = value;
        }
    }

    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }

    public int PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            if (value < 0)
            {
                OnPropertyChanged();
                return;
            }
            _phoneNumber = value;
        }
    }

    public string Email { get; set; }
    public bool IsActive { get; set; } = true;
    public ICommand CloseAddCrewMemberCommand { get; set; }
    public ICommand DeleteCrewMemberCommand { get; set; }

    public string NameWithPosition => string.Concat(Position, ": ", FirstName, " ", LastName);
    public string FullName => string.Concat(FirstName, " ", LastName);
    public string FullAddress => string.Concat(Street, " ", HouseNumber, ", ", PostalCode, " ", City);

    public CrewMemberViewModel()
    {
        Positions = GetPositionsString();
    }

    private static ObservableCollection<string> GetPositionsString()
    {
        var values = Enum.GetValues(typeof(PositionEnum)).Cast<PositionEnum>().Except(new[] { PositionEnum.Admin }).ToList();
        var result = new ObservableCollection<string>();

        foreach (var positionEnum in values)
            result.Add(PositionToStringMapper.MapTo(positionEnum));

        return result;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}