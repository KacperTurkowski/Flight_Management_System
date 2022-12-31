using System;
using System.Windows;
using System.Windows.Input;

namespace FlightManagement.Crew.AddCrewMember
{
    public class CloseAddCrewMemberCommand : ICommand
    {
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is not AddCrewMember addPlaneWindow || addPlaneWindow.DataContext is not CrewMemberViewModel crewMemberViewModel) throw new ArgumentNullException(nameof(parameter));
            
            if (!Validate(crewMemberViewModel))
                return;

            addPlaneWindow.DialogResult = true;
            addPlaneWindow.Close();
        }

        public event EventHandler? CanExecuteChanged {add{} remove{}}

        private bool Validate(CrewMemberViewModel crewMemberViewModel)
        {
            if (string.IsNullOrEmpty(crewMemberViewModel.Position))
                return false;
            return true;
        }
    }
}
