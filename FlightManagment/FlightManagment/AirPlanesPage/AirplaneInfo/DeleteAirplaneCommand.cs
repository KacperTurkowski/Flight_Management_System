using System;
using System.Windows.Input;

namespace FlightManagement.AirPlanesPage.AirplaneInfo
{
    public class DeleteAirplaneCommand : ICommand
    {
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is not AirplaneInfoWindow airplaneInfoWindow) throw new ArgumentNullException(nameof(parameter));
            
            airplaneInfoWindow.DialogResult = true;
            airplaneInfoWindow.Close();
        }

        public event EventHandler? CanExecuteChanged { add{} remove{} }
    }
}
