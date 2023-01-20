using FlightManagement.Base.Position;
using FlightManagement.Base.ViewModels.Airplane;
using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.Data.Models;

namespace FlightManagement.Tests;

public class CrewMemberMapperTests
{
    [Test]
    public void MapToCrewMemberViewModelShouldReturnCrewMemberViewModelModelWhenPassValidArgumentsTest()
    {
        //A
        var crewMember = new CrewMember()
        {
            CrwCity = "Kraków",
            CrwEmail = "mail",
            CrwFirstName = "Kacper",
            CrwLastName = "Turkowski",
            CrwHouseNumber = "54",
            CrwPhoneNumber = 100200300,
            CrwPosition = PositionEnum.Pilot.ToString(),
            CrwPostalCode = "23-204",
            CrwSocialSecurityNumber = 1234567890,
            CrwStreet = "Street",
            CrwIsActive = true
        };
        //A
        var viewModel = CrewMemberMapper.MapTo(crewMember);
        //A
        Assert.That(viewModel.GetType(), Is.EqualTo(typeof(CrewMemberViewModel)));
        Assert.That(viewModel.City, Is.EqualTo("Kraków"));
        Assert.That(viewModel.Email, Is.EqualTo("mail"));
        Assert.That(viewModel.FirstName, Is.EqualTo("Kacper"));
        Assert.That(viewModel.LastName, Is.EqualTo("Turkowski"));
        Assert.That(viewModel.HouseNumber, Is.EqualTo("54"));
        Assert.That(viewModel.PhoneNumber, Is.EqualTo(100200300));
        Assert.That(viewModel.Position, Is.EqualTo(PositionEnum.Pilot.ToString()));
        Assert.That(viewModel.PostalCode, Is.EqualTo("23-204"));
        Assert.That(viewModel.SocialSecurityNumber, Is.EqualTo(1234567890));
        Assert.That(viewModel.Street, Is.EqualTo("Street"));
        Assert.That(viewModel.IsActive, Is.EqualTo(true));
        Assert.That(viewModel.FullName, Is.EqualTo("Kacper Turkowski"));
        Assert.That(viewModel.FullAddress, Is.EqualTo("Street 54, 23-204 Kraków"));
        Assert.That(viewModel.NameWithPosition, Is.EqualTo("Pilot: Kacper Turkowski"));
    }
}