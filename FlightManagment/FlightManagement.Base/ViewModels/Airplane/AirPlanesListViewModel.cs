using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FlightManagement.Base.ViewModels.Airplane;

public class AirPlanesListViewModel : INotifyPropertyChanged
{
    private ObservableCollection<AirplaneViewModel> _airplanes;
    private ICommand _addPlaneCommand;
    private ICommand _openAirplaneInfoCommand;

    public ICommand AddPlaneCommand
    {
        get => _addPlaneCommand;
        set
        {
            if (Equals(value, _addPlaneCommand)) return;
            _addPlaneCommand = value;
            OnPropertyChanged();
        }
    }
    public ICommand OpenAirplaneInfoCommand
    {
        get => _openAirplaneInfoCommand;
        set
        {
            if (Equals(value, _openAirplaneInfoCommand)) return;
            _openAirplaneInfoCommand = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<AirplaneViewModel> Airplanes
    {
        get => _airplanes;
        set
        {
            if (Equals(value, _airplanes)) return;
            _airplanes = value;
            OnPropertyChanged();
        }
    }

    public AirPlanesListViewModel()
    {
        Airplanes = new ObservableCollection<AirplaneViewModel>();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}