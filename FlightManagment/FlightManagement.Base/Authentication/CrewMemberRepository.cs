using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.Data.Models;

namespace FlightManagement.Base.Authentication;

public class CrewMemberRepository
{
    public void SaveCrewMember(CrewMemberViewModel crewMemberViewModel)
    {
        var dbEntity = CrewMemberMapper.MapTo(crewMemberViewModel);
        dbEntity.CrwPassword = dbEntity.CrwSocialSecurityNumber.ToString();
        using var dbContext = new FlightManagementDbContext();
        dbContext.CrewMembers.Add(dbEntity);
        dbContext.SaveChanges();
    }

    public CrewMember? TryGetById(int id)
    {
        using var dbContext = new FlightManagementDbContext();
        return dbContext.CrewMembers.SingleOrDefault(x=>x.CrwId == id);
    }
    public List<CrewMember> GetAllCrewMembers()
    {
        using var dbContext = new FlightManagementDbContext();
        return dbContext.CrewMembers.Where(x=>x.CrwPosition != Position.PositionEnum.Admin.ToString() && x.CrwIsActive == true).ToList();
    }

    public List<CrewMember> GetMembersToApplication()
    {
        using var dbContext = new FlightManagementDbContext();
        return dbContext.CrewMembers.Where(x => (x.CrwPosition == Position.PositionEnum.Admin.ToString() ||
                                                x.CrwPosition == Position.PositionEnum.Controller.ToString())&& x.CrwIsActive == true).ToList();
    }

    public List<CrewMember> GetAllPilots()
    {
        using var dbContext = new FlightManagementDbContext();
        return dbContext.CrewMembers.Where(x => x.CrwPosition == Position.PositionEnum.Pilot.ToString() && x.CrwIsActive == true).ToList();
    }

    public List<CrewMember> GetAllStewards()
    {
        using var dbContext = new FlightManagementDbContext();
        return dbContext.CrewMembers.Where(x => x.CrwPosition == Position.PositionEnum.Steward.ToString() && x.CrwIsActive == true).ToList();
    }

    public void Update(CrewMemberViewModel crewMemberViewModel)
    {
        using var dbContext = new FlightManagementDbContext();
        var crewMemberToUpdate = dbContext.CrewMembers.Single(x => x.CrwId == crewMemberViewModel.Id);
        crewMemberToUpdate.CrwIsActive = crewMemberViewModel.IsActive;
        dbContext.SaveChanges();
    }
}