using FlightManagement.Base.ViewModels.Flights;
using System;
using System.Windows.Input;

namespace FlightManagement.Flights
{
    public class SaveConfigurationCommand : ICommand
    {
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is not FlightConfigurationWindow flightConfigurationWindow || flightConfigurationWindow.DataContext is not FlightViewModel flightViewModel) throw new ArgumentNullException(nameof(parameter));

            flightConfigurationWindow.DialogResult = true;
            flightConfigurationWindow.Close();
        }

        public event EventHandler? CanExecuteChanged { add { } remove { } }
    }
}
