using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FlightManagement.Base.ViewModels.Airplane;

public class AddPlaneViewModel : INotifyPropertyChanged
{
    private string _name;
    private string _producer;
    private bool _isNarrowBody = true;
    private int _maxWeight;
    private int _maxPassengers;
    private int _fuelUsage;

    public string Name
    {
        get => _name;
        set
        {
            if (value == _name) return;
            _name = value;
            OnPropertyChanged();
        }
    }

    public string Producer
    {
        get => _producer;
        set
        {
            if (value == _producer) return;
            _producer = value;
            OnPropertyChanged();
        }
    }

    public bool IsNarrowBody
    {
        get => _isNarrowBody;
        set
        {
            if (value == _isNarrowBody) return;
            _isNarrowBody = value;
            OnPropertyChanged();
        }
    }

    public int MaxWeight
    {
        get => _maxWeight;
        set
        {
            if (value == _maxWeight) return;
            if (value < 0)
            {
                OnPropertyChanged();
                return;
            }
            _maxWeight = value;
            OnPropertyChanged();
        }
    }

    public int MaxPassengers
    {
        get => _maxPassengers;
        set
        {
            if (value == _maxPassengers) return;
            if (value < 0)
            {
                OnPropertyChanged();
                return;
            }
            _maxPassengers = value;
            OnPropertyChanged();
        }
    }

    public int FuelUsage
    {
        get => _fuelUsage;
        set
        {
            if (value.Equals(_fuelUsage)) return;
            if (value < 0)
            {
                OnPropertyChanged();
                return;
            }
            _fuelUsage = value;
            OnPropertyChanged();
        }
    }

    public ICommand CloseAddPlaneWindow { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}