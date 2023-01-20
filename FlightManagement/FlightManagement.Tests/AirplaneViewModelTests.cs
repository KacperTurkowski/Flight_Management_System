using FlightManagement.Base.Position;
using FlightManagement.Base.ViewModels.Airplane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Tests;

internal class AirplaneViewModelTests
{
    [Test]
    public void SetWeightShouldThrowExceptionWhenNegativeValue()
    {
        var airplaneViewModel = new AirplaneViewModel();

        Assert.That(() => airplaneViewModel.MaxWeight = -20, Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void SetMaxPassengersShouldThrowExceptionWhenNegativeValue()
    {
        var airplaneViewModel = new AirplaneViewModel();

        Assert.That(() => airplaneViewModel.MaxPassengers = -20, Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void SetFuelUsageShouldThrowExceptionWhenNegativeValue()
    {
        var airplaneViewModel = new AirplaneViewModel();

        Assert.That(() => airplaneViewModel.FuelUsage = -20, Throws.TypeOf<ArgumentException>());
    }
}

