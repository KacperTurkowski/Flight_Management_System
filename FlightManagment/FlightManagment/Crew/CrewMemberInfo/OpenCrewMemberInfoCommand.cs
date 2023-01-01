using System;
using System.Windows.Input;
using FlightManagement.Base.ViewModels.Crew;

namespace FlightManagement.Crew.CrewMemberInfo
{
    public class OpenCrewMemberInfoCommand : ICommand
    {
        private readonly CrewViewModel _crewViewModel;

        public OpenCrewMemberInfoCommand(CrewViewModel crewViewModel)
        {
            _crewViewModel = crewViewModel;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is not CrewMemberViewModel crewMemberViewModel)
                throw new ArgumentNullException(nameof(parameter));

            var window = new CrewMemberInfo()
            {
                DataContext = crewMemberViewModel
            };
            var toRemove = window.ShowDialog();
            if (toRemove == true)
                _crewViewModel.CrewList.Remove(crewMemberViewModel);

            _crewViewModel.OnPropertyChanged();
            _crewViewModel.OnPropertyChanged(nameof(_crewViewModel.CrewList));
            _crewViewModel.OnPropertyChanged(nameof(_crewViewModel.FilteredCrewList));
        }

        public event EventHandler? CanExecuteChanged { add {} remove {} }
    }
}
