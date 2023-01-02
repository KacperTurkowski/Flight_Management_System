﻿using System.Collections.ObjectModel;
using FlightManagement.Base.Airplanes;
using FlightManagement.Base.Authentication;
using FlightManagement.Base.Flights;
using FlightManagement.Base.ViewModels.Airplane;
using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.Base.ViewModels.Flights;
using FlightManagement.Flights;

namespace FlightManagement.ViewModelsFactories.Flights
{
    public class FlightsListViewModelFactory
    {
        public static FlightsListViewModel Create()
        {
            var flights = new ObservableCollection<FlightViewModel>();
            var crewMemberRepository = new CrewMemberRepository();
            var airPlanesRepository = new AirPlanesRepository();
            foreach (var flight in new FlightsRepository().GetAllFlights())
            {
                var flightViewModel = FlightMapper.MapTo(flight);
                if (flightViewModel.PilotId.HasValue)
                {
                    var pilot = crewMemberRepository.TryGetById(flightViewModel.PilotId.Value);
                    if(pilot != null)
                        flightViewModel.Pilot = CrewMemberMapper.MapTo(pilot);
                }

                if (flightViewModel.AirplaneId.HasValue)
                {
                    var airplane = airPlanesRepository.TryGetById(flightViewModel.AirplaneId.Value);
                    if(airplane != null)
                        flightViewModel.Airplane = AirplaneMapper.MapTo(airplane);
                }

                flights.Add(flightViewModel);
            }

            var result = new FlightsListViewModel()
            {
                Flights = flights
            };
            result.AddFlightCommand = new AddFlightCommand(result);

            return result;
        }
    }
}