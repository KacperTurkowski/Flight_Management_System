using FlightManagement.Base.ViewModels.Flights;
using FlightManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

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

            flightViewModel.ID = dbEntity.FliId;
        }

        public List<Flight> GetAllFlights()
        {
            using var dbContext = new FlightManagementDbContext();
            return dbContext.Flights.Where(x=>x.FliStartDate>DateTime.Now)
                .Include(x=>x.CrewToFlightAssocs)
                .ThenInclude(x=>x.Crw).OrderBy(x=>x.FliStartDate).ToList();
        }

        public List<Flight> GetAllHistoryFlights()
        {
            using var dbContext = new FlightManagementDbContext();
            return dbContext.Flights.Where(x => x.FliStartDate < DateTime.Now && x.CrwId.HasValue)
                .Include(x => x.CrewToFlightAssocs)
                .ThenInclude(x => x.Crw).OrderBy(x => x.FliStartDate).ToList();
        }

        public void FillFlight(FlightViewModel viewModel)
        {
            using var dbContext = new FlightManagementDbContext();
            var dbEntity = dbContext.Flights.Single(x => x.FliId == viewModel.ID);
            dbEntity.AipId = viewModel.Airplane.AirplaneId;
            dbEntity.CrwId = viewModel.Pilot!.Id;
            dbEntity.FliTicketPrice = viewModel.TicketPrice;


            foreach (var crewMemberViewModel in viewModel.Crew)
            {
                dbContext.CrewToFlightAssocs.Add(new CrewToFlightAssoc()
                {
                    CrwId = crewMemberViewModel.Id,
                    FliId = viewModel.ID!.Value
                });
            }
             
            var rnd = new Random();
            dbEntity.FliSoldCargo = rnd.Next(0, viewModel.Airplane.MaxWeight);
            dbEntity.FliSoldTickets = rnd.Next(0, viewModel.Airplane.MaxPassengers);

            dbContext.SaveChanges();
            viewModel.SoldCargo = dbEntity.FliSoldCargo;
            viewModel.SoldTickets = dbEntity.FliSoldTickets;
            viewModel.PilotId = viewModel.Pilot.Id;
            viewModel.AirplaneId = viewModel.Airplane.AirplaneId;
        }

        public void DeleteFlight(FlightViewModel viewModel)
        {
            using var dbContext = new FlightManagementDbContext();
            var dbEntity = dbContext.Flights.Single(x => x.FliId == viewModel.ID);
            

            var toRemove = dbContext.CrewToFlightAssocs.Where(x => x.FliId == viewModel.ID).ToList();
            foreach (var crewToFlightAssoc in toRemove) 
                dbContext.CrewToFlightAssocs.Remove(crewToFlightAssoc);
            
            dbContext.Flights.Remove(dbEntity);
            dbContext.SaveChanges();
        }
    }
}
