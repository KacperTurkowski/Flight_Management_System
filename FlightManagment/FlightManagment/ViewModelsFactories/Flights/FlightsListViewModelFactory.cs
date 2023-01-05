using System.Collections.ObjectModel;
using System.Linq;
using FlightManagement.Base.Airplanes;
using FlightManagement.Base.Authentication;
using FlightManagement.Base.Flights;
using FlightManagement.Base.ViewModels.Airplane;
using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.Base.ViewModels.Flights;
using FlightManagement.Flights;
using FlightManagement.ViewModelsFactories.Crew;

namespace FlightManagement.ViewModelsFactories.Flights
{
    public class FlightsListViewModelFactory
    {
        public static FlightsListViewModel Create(AccountDataProvider accountDataProvider)
        {
            var result = new FlightsListViewModel(accountDataProvider)
            {
                Flights = FlightsInitializer.Initialize(accountDataProvider)
            };
            result.AddFlightCommand = new AddFlightCommand(result);

            return result;
        }
    }
}
