using FlightManagement.Base.ViewModels.Airplane;
using FlightManagement.Data.Models;

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
        }
        public AirPlane? TryGetById(int id)
        {
            using var dbContext = new FlightManagementDbContext();
            return dbContext.AirPlanes.SingleOrDefault(x => x.AipId == id);
        }

        public List<AirPlane> GetAirplanes()
        {
            using var dbContext = new FlightManagementDbContext();
            return dbContext.AirPlanes.ToList();
        }
    }
}
