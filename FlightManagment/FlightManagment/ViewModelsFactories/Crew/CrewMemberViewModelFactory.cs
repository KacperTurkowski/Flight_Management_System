using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.Crew.AddCrewMember;
using FlightManagement.Crew.CrewMemberInfo;

namespace FlightManagement.ViewModelsFactories.Crew
{
    public class CrewMemberViewModelFactory
    {
        public static CrewMemberViewModel Create()
        {
            return new CrewMemberViewModel()
            {

                CloseAddCrewMemberCommand = new CloseAddCrewMemberCommand(),
                DeleteCrewMemberCommand = new DeleteCrewMemberCommand()
            };
        }
    }
}
