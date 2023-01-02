using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.Base.ViewModels.Flights;
using FlightManagement.Data.Models;

namespace FlightManagement.Base.Flights
{
    public class FlightsRepository
    {
        public void SaveFlight(FlightViewModel flightViewModel)
        {
            var dbEntity = FlightMapper.MapTo(flightViewModel);
            using var dbContext = new FlightManagementDbContext();
            dbContext.Flights.Add(dbEntity);
            dbContext.SaveChanges();
        }

        public List<Flight> GetAllFlights()
        {
            using var dbContext = new FlightManagementDbContext();
            return dbContext.Flights.Where(x=>x.FliStartDate>DateTime.Now).ToList();
        }
    }
}
