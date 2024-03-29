﻿using FlightManagement.Base.Airplanes;
using FlightManagement.Base.Authentication;
using FlightManagement.Base.Flights;
using FlightManagement.Base.ViewModels.Airplane;
using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.Base.ViewModels.Flights;
using FlightManagement.ViewModelsFactories.Crew;
using System.Collections.ObjectModel;
using System.Linq;
using FlightManagement.Base.ViewModels;

namespace FlightManagement.ViewModelsFactories.Flights
{
    public class FlightsHistoryViewModelFactory
    {
        public static FlightsHistoryViewModel Create(AccountDataProvider accountDataProvider)
        {
            var flights = new ObservableCollection<FlightViewModel>();
            var crewMemberRepository = new CrewMemberRepository();
            var airPlanesRepository = new AirPlanesRepository();
            foreach (var flight in new FlightsRepository().GetAllHistoryFlights())
            {
                var flightViewModel = FlightMapper.MapTo(flight);
                FlightViewModelFactory.FillHistoryView(flightViewModel, accountDataProvider);
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
                foreach (var crewMember in flight.CrewToFlightAssocs.Select(x => x.Crw))
                {
                    var crewMemberViewModel = CrewMemberMapper.MapTo(crewMember);
                    CrewMemberViewModelFactory.Fill(crewMemberViewModel);
                    flightViewModel.Crew.Add(crewMemberViewModel);
                }

                flights.Add(flightViewModel);
            }

            return new FlightsHistoryViewModel()
            {
                Flights = flights
            };
        }
    }
}
