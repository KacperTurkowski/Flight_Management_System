using FlightManagement.Data.Models;

namespace FlightManagement.Base.ViewModels.Crew;

public class CrewMemberMapper
{
    public static CrewMember MapTo(CrewMemberViewModel crewMember)
    {
        return new CrewMember()
        {
            CrwCity = crewMember.City,
            CrwEmail = crewMember.Email,
            CrwFirstName = crewMember.FirstName,
            CrwLastName = crewMember.LastName,
            CrwHouseNumber = crewMember.HouseNumber,
            CrwPhoneNumber = crewMember.PhoneNumber,
            CrwPosition = crewMember.Position,
            CrwPostalCode = crewMember.PostalCode,
            CrwSocialSecurityNumber = crewMember.SocialSecurityNumber,
            CrwStreet = crewMember.Street
        };
    }

    public static CrewMemberViewModel MapTo(CrewMember crewMember)
    {
        return new CrewMemberViewModel()
        {
            City = crewMember.CrwCity,
            Email = crewMember.CrwEmail,
            FirstName = crewMember.CrwFirstName,
            LastName = crewMember.CrwLastName,
            HouseNumber = crewMember.CrwHouseNumber,
            PhoneNumber = crewMember.CrwPhoneNumber,
            Position = crewMember.CrwPosition,
            PostalCode = crewMember.CrwPostalCode,
            SocialSecurityNumber = crewMember.CrwSocialSecurityNumber,
            Street = crewMember.CrwStreet
        };
    }
}