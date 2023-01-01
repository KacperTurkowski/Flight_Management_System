using System.Collections.ObjectModel;
using FlightManagement.Base.Authentication;
using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.Crew.AddCrewMember;
using FlightManagement.Crew.CrewMemberInfo;

namespace FlightManagement.ViewModelsFactories.Crew
{
    public class CrewViewModelFactory
    {
        public static CrewViewModel Create()
        {
            var viewModel = new CrewViewModel();
            viewModel.CrewList = new ObservableCollection<CrewMemberViewModel>();
            foreach (var crewMember in new CrewMemberRepository().GetAllCrewMembers())
            {
                viewModel.CrewList.Add(CrewMemberMapper.MapTo(crewMember));
            }
            viewModel.AddCrewMemberCommand = new AddCrewMemberCommand(viewModel);
            viewModel.OpenCrewMemberInfoCommand = new OpenCrewMemberInfoCommand(viewModel);
            return viewModel;
        }
    }
}
