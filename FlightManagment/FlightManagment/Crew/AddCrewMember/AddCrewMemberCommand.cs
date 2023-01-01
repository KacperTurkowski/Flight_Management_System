using System;
using System.Windows.Input;
using FlightManagement.Base.Authentication;
using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.ViewModelsFactories.Crew;

namespace FlightManagement.Crew.AddCrewMember
{
    public class AddCrewMemberCommand : ICommand
    {
        private readonly CrewViewModel _crewViewModel;

        public AddCrewMemberCommand(CrewViewModel crewViewModel)
        {
            _crewViewModel = crewViewModel;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            var addCrewMember = new AddCrewMember();
            var crewMemberViewModel = CrewMemberViewModelFactory.Create();
            addCrewMember.DataContext = crewMemberViewModel;
            var result = addCrewMember.ShowDialog();

            if (result == true)
            {
                new CrewMemberRepository().SaveCrewMember(crewMemberViewModel);
                _crewViewModel.CrewList.Add(crewMemberViewModel);
            }
            _crewViewModel.OnPropertyChanged();
            _crewViewModel.OnPropertyChanged(nameof(_crewViewModel.CrewList));
            _crewViewModel.OnPropertyChanged(nameof(_crewViewModel.FilteredCrewList));
        }

        public event EventHandler? CanExecuteChanged {add{} remove{}}
    }
}
