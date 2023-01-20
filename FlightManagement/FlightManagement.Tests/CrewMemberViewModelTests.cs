using FlightManagement.Base.ViewModels.Airplane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagement.Base.Position;
using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.Data.Models;

namespace FlightManagement.Tests;

internal class CrewMemberViewModelTests
{
    [Test]
    public void SetSocialSecurityNumberShouldNotSetValueWhenNegativeValue()
    {
        var crewMemberViewModel = new CrewMemberViewModel();

        crewMemberViewModel.SocialSecurityNumber = -10;

        Assert.That(crewMemberViewModel.SocialSecurityNumber, Is.EqualTo(0));
    }

    [Test]
    public void SetPhoneNumberShouldNotSetValueWhenNegativeValue()
    {
        var crewMemberViewModel = new CrewMemberViewModel();

        crewMemberViewModel.PhoneNumber = -10;

        Assert.That(crewMemberViewModel.PhoneNumber, Is.EqualTo(0));
    }

    [Test]
    public void GetNameWithPositionShouldReturnValidNameAlways()
    {
        var crewMemberViewModel = new CrewMemberViewModel();

        crewMemberViewModel.Position = PositionEnum.Controller.ToString();
        crewMemberViewModel.FirstName = "Julia";
        crewMemberViewModel.LastName = "Kwiat";


        Assert.That(crewMemberViewModel.NameWithPosition, Is.EqualTo("Controller: Julia Kwiat"));
    }

    [Test]
    public void GetFullNameShouldReturnValidNameAlways()
    {
        var crewMemberViewModel = new CrewMemberViewModel();

        crewMemberViewModel.FirstName = "Julia";
        crewMemberViewModel.LastName = "Kwiat";


        Assert.That(crewMemberViewModel.FullName, Is.EqualTo("Julia Kwiat"));
    }

    [Test]
    public void GetFullAddressShouldReturnValidAddressAlways()
    {
        var crewMemberViewModel = new CrewMemberViewModel()
        {
            City = "Kraków",
            HouseNumber = "54",
            PostalCode = "23-204",
            Street = "Street",
        };


        Assert.That(crewMemberViewModel.FullAddress, Is.EqualTo("Street 54, 23-204 Kraków"));

    }
}

