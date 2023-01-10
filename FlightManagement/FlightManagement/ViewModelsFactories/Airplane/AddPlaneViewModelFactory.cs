using FlightManagement.AirPlanesPage.AddPlane;
using FlightManagement.Base.ViewModels.Airplane;

namespace FlightManagement.ViewModelsFactories.Airplane
{
    public class AddPlaneViewModelFactory
    {
        public static AddPlaneViewModel Create()
        {
            return new AddPlaneViewModel()
            {
                CloseAddPlaneWindow = new CloseAddPlaneCommand()
            };
        }
    }
}
