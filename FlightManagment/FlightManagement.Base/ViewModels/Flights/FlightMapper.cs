using FlightManagement.Data.Models;

namespace FlightManagement.Base.ViewModels.Flights
{
    public class FlightMapper
    {
        public static Flight MapTo(FlightViewModel flight)
        {
            return new Flight()
            {
                FliStartAirport = flight.StartAirport,
                FliEndAirport = flight.EndAirport,
                FliStartPlace = flight.StartPlace,
                FliEndPlace = flight.EndPlace,
                FliFlightLength = flight.FlightLength,
                FliStartDate = flight.StartDate,
                FliSoldTickets = flight.SoldTickets,
                FliSoldCargo = flight.SoldCargo,
                CrwId = flight.PilotId,
                AipId = flight.AirplaneId
            };
        }

        public static FlightViewModel MapTo(Flight flight)
        {
            return new FlightViewModel()
            {
                StartAirport = flight.FliStartAirport,
                EndAirport = flight.FliEndAirport,
                StartPlace = flight.FliStartPlace,
                EndPlace = flight.FliEndPlace,
                FlightLength = flight.FliFlightLength,
                StartDate = flight.FliStartDate,
                SoldTickets = flight.FliSoldTickets,
                SoldCargo = flight.FliSoldCargo,
                PilotId = flight.CrwId,
                AirplaneId = flight.AipId
            };
        }
    }
}
