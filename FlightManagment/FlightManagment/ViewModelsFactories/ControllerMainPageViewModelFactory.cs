using System;
using System.Collections.ObjectModel;
using FlightManagement.Base.ViewModels;
using FlightManagement.Base.ViewModels.Airplane;
using FlightManagement.Base.ViewModels.Flights;

namespace FlightManagement.ViewModelsFactories
{
    public class ControllerMainPageViewModelFactory
    {
        public static ControllerMainPageViewModel Create()
        {
            return new ControllerMainPageViewModel()
            {
                Flights = new ObservableCollection<FlightViewModel>()
                {
                    new FlightViewModel()
                    {
                        Airplane = new AirplaneViewModel()
                        {
                            Name = "boeing"
                        },
                        StartDate = DateTime.Now,
                        StartAirport = "KRK",
                        EndAirport = "WRS"
                    },
                    new FlightViewModel()
                    {
                        Airplane = new AirplaneViewModel()
                        {
                            Name = "boeing 737"
                        },
                        StartDate = DateTime.Now,
                        StartAirport = "KRK",
                        EndAirport = "GDK"
                    },
                }
            };
        }
    }
}
