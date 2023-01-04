using System;
using System.Collections.ObjectModel;
using FlightManagement.Base.Airplanes;
using FlightManagement.Base.Authentication;
using FlightManagement.Base.Flights;
using FlightManagement.Base.ViewModels;
using FlightManagement.Base.ViewModels.Airplane;
using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.Base.ViewModels.Flights;
using FlightManagement.ViewModelsFactories.Flights;

namespace FlightManagement.ViewModelsFactories
{
    public class ControllerMainPageViewModelFactory
    {
        public static ControllerMainPageViewModel Create(AccountDataProvider accountDataProvider)
        {
            var flights = new ObservableCollection<FlightViewModel>();
            var crewMemberRepository = new CrewMemberRepository();
            var airPlanesRepository = new AirPlanesRepository();
            foreach (var flight in new FlightsRepository().GetAllFlights())
            {
                var flightViewModel = FlightMapper.MapTo(flight);
                FlightViewModelFactory.Fill(flightViewModel, accountDataProvider);
                if (flightViewModel.PilotId.HasValue)
                {
                    var pilot = crewMemberRepository.TryGetById(flightViewModel.PilotId.Value);
                    if (pilot != null)
                        flightViewModel.Pilot = CrewMemberMapper.MapTo(pilot);
                }

                if (flightViewModel.AirplaneId.HasValue)
                {
                    var airplane = airPlanesRepository.TryGetById(flightViewModel.AirplaneId.Value);
                    if (airplane != null)
                        flightViewModel.Airplane = AirplaneMapper.MapTo(airplane);
                }

                flights.Add(flightViewModel);
            }


            return new ControllerMainPageViewModel()
            {
                Flights =  flights
            };
        }
    }
}
