using FlightManagement.Base.ViewModels.Flights;
using FlightManagement.ViewConstants;
using System;
using System.Windows;
using System.Windows.Input;

namespace FlightManagement.Flights
{
    public class SaveConfigurationCommand : ICommand
    {
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is not FlightConfigurationWindow flightConfigurationWindow || flightConfigurationWindow.DataContext is not FlightViewModel flightViewModel) throw new ArgumentNullException(nameof(parameter));

            if (!Verify(flightViewModel, flightConfigurationWindow))
                return;

            flightConfigurationWindow.DialogResult = true;
            flightConfigurationWindow.Close();
        }

        private bool Verify(FlightViewModel flightViewModel, FlightConfigurationWindow window)
        {
            if (flightViewModel.Airplane == null)
            {
                MessageBox.Show(window, "Wybierz samolot", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (flightViewModel.Pilot == null)
            {
                MessageBox.Show(window, "Wybierz pilota", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (flightViewModel.Crew.Count < 4)
            {
                MessageBox.Show(window, "Minimalna ilośc załogi to 4", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (flightViewModel.TicketPrice == 0)
            {
                MessageBox.Show(window, "Podaj cenę biletu", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public event EventHandler? CanExecuteChanged { add { } remove { } }
    }
}
