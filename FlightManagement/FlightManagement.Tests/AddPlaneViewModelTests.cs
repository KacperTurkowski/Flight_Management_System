using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagement.Base.ViewModels.Airplane;

namespace FlightManagement.Tests;

internal class AddPlaneViewModelTests
{
    [Test]
    public void SetWeightShouldNotSetValueWhenNegativeValue()
    {
        var addPlaneViewModel = new AddPlaneViewModel();

        addPlaneViewModel.MaxWeight = -20;

        Assert.That(addPlaneViewModel.MaxWeight, Is.EqualTo(0));
    }

    [Test]
    public void SetMaxPassengersShouldNotSetValueWhenNegativeValue()
    {
        var addPlaneViewModel = new AddPlaneViewModel();

        addPlaneViewModel.MaxPassengers = -20;

        Assert.That(addPlaneViewModel.MaxPassengers, Is.EqualTo(0));
    }

    [Test]
    public void SetFuelUsageShouldNotSetValueWhenNegativeValue()
    {
        var addPlaneViewModel = new AddPlaneViewModel();

        addPlaneViewModel.FuelUsage = -20;

        Assert.That(addPlaneViewModel.FuelUsage, Is.EqualTo(0));
    }
}

