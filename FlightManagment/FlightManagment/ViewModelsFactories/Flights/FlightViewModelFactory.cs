using FlightManagement.Base.ViewModels.Flights;
using FlightManagement.Flights;

namespace FlightManagement.ViewModelsFactories.Flights
{
    public class FlightViewModelFactory
    {
        public static FlightViewModel Create()
        {
            return new FlightViewModel()
            {
                CloseAddFlightWindowCommand = new CloseAddFlightWindowCommand()
            };
        }
    }
}
