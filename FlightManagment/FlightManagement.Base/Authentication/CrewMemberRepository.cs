using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.Data.Models;

namespace FlightManagement.Base.Authentication;

public class CrewMemberRepository
{
    public void SaveCrewMember(CrewMemberViewModel crewMemberViewModel)
    {
        var dbEntity = CrewMemberMapper.MapTo(crewMemberViewModel);

        using var dbContext = new FlightManagementDbContext();
        dbContext.CrewMembers.Add(dbEntity);
        dbContext.SaveChanges();
    }

    public List<CrewMember> GetAllCrewMembers()
    {
        using var dbContext = new FlightManagementDbContext();
        return dbContext.CrewMembers.Where(x=>x.CrwPosition != Position.PositionEnum.Admin.ToString()).ToList();
    }

    public List<CrewMember> GetMembersToApplication()
    {
        using var dbContext = new FlightManagementDbContext();
        return dbContext.CrewMembers.Where(x => x.CrwPosition == Position.PositionEnum.Admin.ToString() ||
                                                x.CrwPosition == Position.PositionEnum.Controller.ToString()).ToList();
    }
}