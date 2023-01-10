using System.Collections.ObjectModel;
using FlightManagement.AirPlanesPage.AddPlane;
using FlightManagement.AirPlanesPage.AirplaneInfo;
using FlightManagement.Base.Airplanes;
using FlightManagement.Base.ViewModels.Airplane;

namespace FlightManagement.ViewModelsFactories.Airplane;

public class AirPlanesListViewModelFactory
{
    public static AirPlanesListViewModel Create()
    {
        var result = new AirPlanesListViewModel();
        result.Airplanes = new ObservableCollection<AirplaneViewModel>();

        var airplanes = new AirPlanesRepository().GetAirplanes();
        foreach (var airplane in airplanes)
        {
            var airplaneViewModel = AirplaneMapper.MapTo(airplane);
            AirplaneViewModelFactory.Fill(airplaneViewModel);
            result.Airplanes.Add(airplaneViewModel);
        }

        result.AddPlaneCommand = new AddPlaneCommand(result);
        result.OpenAirplaneInfoCommand = new OpenAirplaneInfoCommand(result);
        return result;
    }
}