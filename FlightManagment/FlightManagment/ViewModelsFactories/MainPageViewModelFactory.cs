using FlightManagement.Base.Authentication;
using FlightManagement.Base.ViewModels;
using FlightManagement.ViewModelsFactories.Airplane;
using FlightManagement.ViewModelsFactories.Crew;
using FlightManagement.ViewModelsFactories.Flights;

namespace FlightManagement.ViewModelsFactories
{
    public class MainPageViewModelFactory
    {
        public static MainPageViewModel Create(AccountDataProvider accountDataProvider)
        {
            return new MainPageViewModel()
            {
                AirPlanesListViewModel = AirPlanesListViewModelFactory.Create(),
                CrewViewModel = CrewViewModelFactory.Create(),
                FlightsListViewModel = FlightsListViewModelFactory.Create(accountDataProvider)
            };
        }
    }
}
