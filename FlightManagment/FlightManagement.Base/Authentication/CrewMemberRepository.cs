using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

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

        crewMemberViewModel.Id = dbEntity.CrwId;
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

    public List<CrewMember> GetAllFreePilots(DateTime dateTime)
    {

        using var dbContext = new FlightManagementDbContext();
        var allPilots = dbContext.CrewMembers.Where(x => x.CrwPosition == Position.PositionEnum.Pilot.ToString() && x.CrwIsActive == true).Include(x=>x.Flights).ToList();

        var result = new List<CrewMember>();
        foreach (var crewMember in allPilots)
        {
            var checkAvaible = true;
            foreach (var flights in crewMember.Flights)
            {
                if (dateTime.AddHours(-2) < flights.FliStartDate && flights.FliStartDate < dateTime.AddHours(+2))
                {
                    checkAvaible = false;
                    break;
                }
            }
            if(checkAvaible)
                result.Add(crewMember);
        }

        return result;
    }

    public List<CrewMember> GetAllFreeStewards(DateTime dateTime)
    {
        using var dbContext = new FlightManagementDbContext();
        var allCrewMembers = dbContext.CrewMembers.Where(x => x.CrwPosition == Position.PositionEnum.Steward.ToString() && x.CrwIsActive == true).ToList();
        var allFlights = dbContext.CrewToFlightAssocs.Include(x => x.Fli).ToList();
        var result = new List<CrewMember>();
        foreach (var crewMember in allCrewMembers)
        {
            var checkAvaible = true;
            foreach (var flights in allFlights.Where(x=>x.CrwId == crewMember.CrwId))
            {
                if (dateTime.AddHours(-2) < flights.Fli.FliStartDate && flights.Fli.FliStartDate < dateTime.AddHours(+2))
                {
                    checkAvaible = false;
                    break;
                }
            }
            if (checkAvaible)
                result.Add(crewMember);
        }

        return result;
    }

    public void Update(CrewMemberViewModel crewMemberViewModel)
    {
        using var dbContext = new FlightManagementDbContext();
        var crewMemberToUpdate = dbContext.CrewMembers.Single(x => x.CrwId == crewMemberViewModel.Id);
        crewMemberToUpdate.CrwIsActive = crewMemberViewModel.IsActive;
        dbContext.SaveChanges();
    }
}