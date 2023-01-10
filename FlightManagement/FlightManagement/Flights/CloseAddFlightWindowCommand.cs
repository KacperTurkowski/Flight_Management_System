using System;
using System.Windows;
using System.Windows.Input;
using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.Base.ViewModels.Flights;
using FlightManagement.ViewConstants;

namespace FlightManagement.Flights
{
    internal class CloseAddFlightWindowCommand : ICommand
    {
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is not AddFlightWindow addFlightWindow || addFlightWindow.DataContext is not FlightViewModel flightViewModel) throw new ArgumentNullException(nameof(parameter));

            if (!Verify(flightViewModel, addFlightWindow))
                return;

            var date = flightViewModel.StartDate.Date;
            date = date.AddHours(int.Parse(flightViewModel.Hour));
            date = date.AddMinutes(int.Parse(flightViewModel.Minute));
            flightViewModel.StartDate = date;
            
            addFlightWindow.DialogResult = true;
            addFlightWindow.Close();
        }

        private bool Verify(FlightViewModel viewModel, Window window)
        {
            if (string.IsNullOrEmpty(viewModel.StartAirport) || viewModel.StartAirport == StringStatic.StartAirportPlaceholder)
            {
                MessageBox.Show(window, "Podaj lotnisko startowe", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(viewModel.EndAirport) || viewModel.EndAirport == StringStatic.EndAirportPlaceholder)
            {
                MessageBox.Show(window, "Podaj lotnisko docelowe", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(viewModel.StartPlace) || viewModel.StartPlace == StringStatic.StartPlacePlaceholder)
            {
                MessageBox.Show(window, "Podaj miasto wylotu", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(viewModel.EndPlace) || viewModel.EndPlace == StringStatic.EndPlacePlaceholder)
            {
                MessageBox.Show(window, "Podaj miasto docelowe", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (viewModel.FlightLength == 0)
            {
                MessageBox.Show(window, "Podaj długość lotu", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(viewModel.Hour) || string.IsNullOrEmpty(viewModel.Minute))
            {
                MessageBox.Show(window, "Podaj godzinę lotu", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public event EventHandler? CanExecuteChanged{add{} remove {}}
    }
}
