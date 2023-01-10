using FlightManagement.Base.ViewModels.Airplane;
using FlightManagement.ViewConstants;
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
            if (parameter is not Window addPlaneWindow || addPlaneWindow.DataContext is not AddPlaneViewModel viewModel) throw new ArgumentNullException(nameof(parameter));
            
            if (!Verify(viewModel, addPlaneWindow))
                return;

            addPlaneWindow.DialogResult = true;
            addPlaneWindow.Close();
        }

        private bool Verify(AddPlaneViewModel addPlaneViewModel, Window window)
        {
            if (string.IsNullOrEmpty(addPlaneViewModel.Name) || addPlaneViewModel.Name == StringStatic.NamePlaceholder)
            {
                MessageBox.Show(window,"Podaj nazwę samolotu", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(addPlaneViewModel.Producer) || addPlaneViewModel.Name == StringStatic.ProducerPlaceholder)
            {
                MessageBox.Show(window, "Podaj markę samolotu", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (addPlaneViewModel.MaxWeight == 0)
            {
                MessageBox.Show(window, "Podaj maksymalny tonaż samolotu", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (addPlaneViewModel.MaxPassengers == 0)
            {
                MessageBox.Show(window, "Podaj maksymalną liczbę pasażerów", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (addPlaneViewModel.FuelUsage == 0)
            {
                MessageBox.Show(window, "Podaj spalanie samolotu", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public event EventHandler? CanExecuteChanged { add{} remove{} }
    }
}
