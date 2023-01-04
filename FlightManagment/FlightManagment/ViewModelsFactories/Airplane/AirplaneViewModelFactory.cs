using FlightManagement.AirPlanesPage.AirplaneInfo;
using FlightManagement.Base.ViewModels.Airplane;

namespace FlightManagement.ViewModelsFactories.Airplane;

public class AirplaneViewModelFactory
{
    public static AirplaneViewModel Create()
    {
        return new AirplaneViewModel()
        {
            DeleteAirplaneCommand = new DeleteAirplaneCommand()
        };
    }

    public static void Fill(AirplaneViewModel airplaneViewModel)
    {
        airplaneViewModel.DeleteAirplaneCommand = new DeleteAirplaneCommand();
    }
}