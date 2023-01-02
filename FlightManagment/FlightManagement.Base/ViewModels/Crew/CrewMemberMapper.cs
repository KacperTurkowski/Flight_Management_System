using FlightManagement.Base.Position;
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
            CrwPosition = crewMember.PositionEnum.ToString(),
            CrwPostalCode = crewMember.PostalCode,
            CrwSocialSecurityNumber = crewMember.SocialSecurityNumber,
            CrwStreet = crewMember.Street,
            CrwIsActive = crewMember.IsActive
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
            Position = PositionToStringMapper.Translate(crewMember.CrwPosition),
            PostalCode = crewMember.CrwPostalCode,
            SocialSecurityNumber = crewMember.CrwSocialSecurityNumber,
            Street = crewMember.CrwStreet,
            IsActive = crewMember.CrwIsActive,
            Id = crewMember.CrwId
        };
    }
}