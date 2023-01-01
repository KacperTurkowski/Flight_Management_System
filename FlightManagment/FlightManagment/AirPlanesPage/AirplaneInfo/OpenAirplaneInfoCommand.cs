using System;
using System.Windows.Input;
using FlightManagement.Base.ViewModels.Airplane;

namespace FlightManagement.AirPlanesPage.AirplaneInfo;

public class OpenAirplaneInfoCommand : ICommand
{
    private readonly AirPlanesListViewModel _airPlanesListViewModel;

    public OpenAirplaneInfoCommand(AirPlanesListViewModel airPlanesListViewModel)
    {
        _airPlanesListViewModel = airPlanesListViewModel;
    }

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        if (parameter is not AirplaneViewModel airplaneViewModel) throw new ArgumentNullException(nameof(parameter));

        var window = new AirplaneInfoWindow
        {
            DataContext = airplaneViewModel
        };
        var toRemove = window.ShowDialog();
        if (toRemove == true)
            _airPlanesListViewModel.Airplanes.Remove(airplaneViewModel);

        _airPlanesListViewModel.OnPropertyChanged();
    }

    public event EventHandler? CanExecuteChanged { add{} remove{} }
}