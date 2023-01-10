using FlightManagement.Base.ViewModels.Flights;
using System;
using System.Windows;
using System.Windows.Input;

namespace FlightManagement.Flights
{
    public class DeleteFlightCommand : ICommand
    {
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is not Window flightWindow || flightWindow.DataContext is not FlightViewModel flightViewModel) throw new ArgumentNullException(nameof(parameter));

            flightWindow.DialogResult = true;
            flightWindow.Close();
        }

        public event EventHandler? CanExecuteChanged { add { } remove { } }
    }
}
