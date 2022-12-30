using System;
using System.Windows;
using System.Windows.Input;

namespace FlightManagement.AirPlanesPage.AddPlane
{
    public class CloseAddPlaneCommand : ICommand
    {
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is not Window addPlaneWindow) throw new ArgumentNullException(nameof(parameter));

            //TODO verify data

            addPlaneWindow.DialogResult = true;
            addPlaneWindow.Close();
        }

        public event EventHandler? CanExecuteChanged;
    }
}
