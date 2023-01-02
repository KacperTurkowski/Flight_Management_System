﻿using FlightManagement.Base.ViewModels;
using FlightManagement.ViewModelsFactories.Airplane;
using FlightManagement.ViewModelsFactories.Crew;
using FlightManagement.ViewModelsFactories.Flights;

namespace FlightManagement.ViewModelsFactories
{
    public class MainPageViewModelFactory
    {
        public static MainPageViewModel Create()
        {
            return new MainPageViewModel()
            {
                AirPlanesListViewModel = AirPlanesListViewModelFactory.Create(),
                CrewViewModel = CrewViewModelFactory.Create(),
                FlightsListViewModel = FlightsListViewModelFactory.Create()
            };
        }
    }
}