using FlightManagement.Data.Models;

namespace FlightManagement.Base.ViewModels.Airplane
{
    public class AirplaneMapper
    {
        public static AirPlane MapTo(AirplaneViewModel airplaneViewModel)
        {
            return new AirPlane()
            {
                AipFuelUsage = airplaneViewModel.FuelUsage,
                AipIsNarrowBody = airplaneViewModel.IsNarrowBody,
                AipMaxPassengers = airplaneViewModel.MaxPassengers,
                AipMaxWeight = airplaneViewModel.MaxWeight,
                AipProducer = airplaneViewModel.Producer,
                AipName = airplaneViewModel.Name
            };
        }

        public static AirplaneViewModel MapTo(AirPlane airPlane)
        {
            return new AirplaneViewModel()
            {
                FuelUsage = airPlane.AipFuelUsage,
                IsNarrowBody = airPlane.AipIsNarrowBody,
                MaxPassengers = airPlane.AipMaxPassengers,
                MaxWeight = airPlane.AipMaxWeight,
                Producer = airPlane.AipProducer,
                Name = airPlane.AipName
            };
        }
    }
}
