using System;
using System.Collections.ObjectModel;
using System.Linq;
using FlightManagement.Base.Airplanes;
using FlightManagement.Base.Authentication;
using FlightManagement.Base.Flights;
using FlightManagement.Base.ViewModels;
using FlightManagement.Base.ViewModels.Airplane;
using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.Base.ViewModels.Flights;
using FlightManagement.ViewModelsFactories.Crew;
using FlightManagement.ViewModelsFactories.Flights;

namespace FlightManagement.ViewModelsFactories
{
    public class ControllerMainPageViewModelFactory
    {
        public static ControllerMainPageViewModel Create(AccountDataProvider accountDataProvider)
        {
            return new ControllerMainPageViewModel()
            {
                Flights = FlightsInitializer.Initialize(accountDataProvider)
            };
        }
    }
}
