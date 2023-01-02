using System;
using System.Windows.Input;
using FlightManagement.Base.ViewModels.Flights;

namespace FlightManagement.Flights
{
    internal class CloseAddFlightWindowCommand : ICommand
    {
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is not AddFlightWindow addFlightWindow || addFlightWindow.DataContext is not FlightViewModel flightViewModel) throw new ArgumentNullException(nameof(parameter));

            var date = flightViewModel.StartDate.Date;
            date = date.AddHours(int.Parse(flightViewModel.Hour));
            date = date.AddMinutes(int.Parse(flightViewModel.Minute));
            flightViewModel.StartDate = date;

            addFlightWindow.DialogResult = true;
            addFlightWindow.Close();
        }

        public event EventHandler? CanExecuteChanged{add{} remove {}}
    }
}
