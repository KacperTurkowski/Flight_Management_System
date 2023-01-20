using FlightManagement.Base.Position;
using FlightManagement.Base.ViewModels.Airplane;
using FlightManagement.Data.Models;

namespace FlightManagement.Tests;

public class AirplaneMapperTests
{
    [Test]
    public void MapToAirPlaneViewModelShouldReturnAirplaneViewModelWhenPassValidArgumentsTest()
    {
        //A
        var airPlane = new AirPlane
        {
            AipFuelUsage = 1,
            AipId = 2,
            AipIsActivated = true,
            AipIsNarrowBody = true,
            AipMaxPassengers = 5,
            AipMaxWeight = 6,
            AipName = "Samolot",
            AipProducer = "Boeing"
        };
        //A
        var viewModel = AirplaneMapper.MapTo(airPlane);
        //A
        Assert.That(viewModel.GetType(), Is.EqualTo(typeof(AirplaneViewModel)));
        Assert.That(viewModel.FuelUsage, Is.EqualTo(1));
        Assert.That(viewModel.AirplaneId, Is.EqualTo(2));
        Assert.That(viewModel.IsNarrowBody, Is.EqualTo(true));
        Assert.That(viewModel.MaxPassengers, Is.EqualTo(5));
        Assert.That(viewModel.MaxWeight, Is.EqualTo(6));
        Assert.That(viewModel.Name, Is.EqualTo("Samolot"));
        Assert.That(viewModel.Producer, Is.EqualTo("Boeing"));
        Assert.That(viewModel.NarrowBodyName, Is.EqualTo("Wąskokadłubowy"));
    }
    [Test]
    public void MapToAirPlaneShouldReturnAirplaneWhenPassValidArgumentsTest()
    {
        //A
        var viewModel = new AirplaneViewModel
        {
            AirplaneId = 3,
            FuelUsage = 5,
            IsNarrowBody = true,
            MaxPassengers = 4,
            MaxWeight = 56,
            Name = "Samolot 2",
            Producer = "xyz"
        };
        //A
        var airPlane = AirplaneMapper.MapTo(viewModel);
        //A
        Assert.That(airPlane.GetType(), Is.EqualTo(typeof(AirPlane)));
        Assert.That(airPlane.AipFuelUsage, Is.EqualTo(5));
        Assert.That(airPlane.AipId, Is.EqualTo(0));
        Assert.That(airPlane.AipIsNarrowBody, Is.EqualTo(true));
        Assert.That(airPlane.AipMaxPassengers, Is.EqualTo(4));
        Assert.That(airPlane.AipMaxWeight, Is.EqualTo(56));
        Assert.That(airPlane.AipName, Is.EqualTo("Samolot 2"));
        Assert.That(airPlane.AipProducer, Is.EqualTo("xyz"));
        Assert.That(airPlane.AipIsActivated, Is.EqualTo(true));
    }
}