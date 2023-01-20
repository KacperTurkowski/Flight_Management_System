using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagement.Base.ViewModels.Flights;

namespace FlightManagement.Tests;

internal class FlightViewModelTests
{
    [Test]
    public void GetTitleShouldReturnValidTitleAlways()
    {
        var flightViewModel = new FlightViewModel();

        flightViewModel.StartAirport = "JFK";
        flightViewModel.EndAirport = "KRK";

        Assert.AreEqual("JFK->KRK",flightViewModel.Title);
    }

    [Test]
    public void SetFlightLengthShouldNotSetValueWhenNegativeValue()
    {
        var flightViewModel = new FlightViewModel();

        flightViewModel.FlightLength = -500;

        Assert.AreEqual(null, flightViewModel.FlightLength);
    }

    [Test]
    public void SetStartShouldNotSetValueWhenNegativeValue()
    {
        var flightViewModel = new FlightViewModel();
        var expectedDate = new DateTime(3000, 1, 1);
        
        flightViewModel.StartDate = expectedDate;
        flightViewModel.StartDate = DateTime.Now.AddDays(-200);

        Assert.AreEqual(expectedDate, flightViewModel.StartDate);
    }


    [Test]
    public void SetSoldCargoShouldNotSetValueWhenNegativeValue()
    {
        var flightViewModel = new FlightViewModel();

        flightViewModel.SoldCargo = -500;

        Assert.AreEqual(0, flightViewModel.SoldCargo);
    }

    [Test]
    public void SetSoldTicketsShouldNotSetValueWhenNegativeValue()
    {
        var flightViewModel = new FlightViewModel();

        flightViewModel.SoldTickets = -500;

        Assert.AreEqual(0, flightViewModel.SoldTickets);
    }

    [Test]
    public void SetTicketPriceShouldNotSetValueWhenNegativeValue()
    {
        var flightViewModel = new FlightViewModel();

        flightViewModel.TicketPrice = -500;

        Assert.AreEqual(null, flightViewModel.TicketPrice);
    }
}