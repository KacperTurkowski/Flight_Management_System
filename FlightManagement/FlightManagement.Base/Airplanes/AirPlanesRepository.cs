using FlightManagement.Base.ViewModels.Airplane;
using FlightManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightManagement.Base.Airplanes
{
    public class AirPlanesRepository
    {
        public void SaveAirPlane(AirplaneViewModel airplaneViewModel)
        {
            var dbEntity = AirplaneMapper.MapTo(airplaneViewModel);
            using var dbContext = new FlightManagementDbContext();
            dbContext.AirPlanes.Add(dbEntity);
            dbContext.SaveChanges();

            airplaneViewModel.AirplaneId = dbEntity.AipId;
        }
        public AirPlane? TryGetById(int id)
        {
            using var dbContext = new FlightManagementDbContext();
            return dbContext.AirPlanes.SingleOrDefault(x => x.AipId == id);
        }
        public List<AirPlane> GetAllFreeAirplanes(DateTime dateTime)
        {
            using var dbContext = new FlightManagementDbContext();
            var allAirplanes = dbContext.AirPlanes.Where(x => x.AipIsActivated).Include(x => x.Flights).ToList();

            var result = new List<AirPlane>();
            foreach (var airplane in allAirplanes)
            {
                var checkAvaible = true;
                foreach (var flights in airplane.Flights)
                {
                    if (dateTime.AddHours(-2) < flights.FliStartDate && flights.FliStartDate < dateTime.AddHours(+2))
                    {
                        checkAvaible = false;
                        break;
                    }
                }
                if (checkAvaible)
                    result.Add(airplane);
            }

            return result;
        }

        public List<AirPlane> GetAirplanes()
        {
            using var dbContext = new FlightManagementDbContext();
            return dbContext.AirPlanes.Where(x=>x.AipIsActivated).ToList();
        }

        public void Deactivate(int id)
        {
            using var dbContext = new FlightManagementDbContext();
            var airPlane = dbContext.AirPlanes.SingleOrDefault(x => x.AipId == id);
            if (airPlane != null)
            {
                airPlane.AipIsActivated = false;
                dbContext.SaveChanges();
            }
        }
    }
}
