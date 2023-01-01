using System.Collections.ObjectModel;
using FlightManagement.AirPlanesPage.AddPlane;
using FlightManagement.AirPlanesPage.AirplaneInfo;
using FlightManagement.Base.ViewModels.Airplane;

namespace FlightManagement.ViewModelsFactories.Airplane;

public class AirPlanesListViewModelFactory
{
    public static AirPlanesListViewModel Create()
    {
        var result = new AirPlanesListViewModel();
        result.Airplanes = new ObservableCollection<AirplaneViewModel>();

        result.AddPlaneCommand = new AddPlaneCommand(result);
        result.OpenAirplaneInfoCommand = new OpenAirplaneInfoCommand(result);
        return result;
    }
}