using System;
using System.Windows.Input;

namespace FlightManagement.Crew.CrewMemberInfo
{
    public class DeleteCrewMemberCommand : ICommand
    {
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is not CrewMemberInfo crewMemberInfo) throw new ArgumentNullException(nameof(parameter));

            crewMemberInfo.DialogResult = true;
            crewMemberInfo.Close();
        }

        public event EventHandler? CanExecuteChanged{add{} remove{}}
    }
}
