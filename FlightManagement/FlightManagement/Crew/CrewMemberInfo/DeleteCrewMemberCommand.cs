using System;
using System.Windows.Input;
using FlightManagement.Base.Authentication;
using FlightManagement.Base.ViewModels.Crew;

namespace FlightManagement.Crew.CrewMemberInfo
{
    public class DeleteCrewMemberCommand : ICommand
    {
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is not CrewMemberInfo crewMemberInfo || crewMemberInfo.DataContext is not CrewMemberViewModel crewMemberViewModel) throw new ArgumentNullException(nameof(parameter));

            crewMemberViewModel.IsActive = false;
            new CrewMemberRepository().Update(crewMemberViewModel);
            crewMemberInfo.DialogResult = true;
            crewMemberInfo.Close();
        }

        public event EventHandler? CanExecuteChanged{add{} remove{}}
    }
}
