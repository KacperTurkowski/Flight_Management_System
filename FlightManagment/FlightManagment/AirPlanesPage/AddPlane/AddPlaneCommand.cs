using System;
using System.Windows.Input;

namespace FlightManagement.AirPlanesPage.AddPlane
{
    public class AddPlaneCommand : ICommand
    {
        private readonly AirPlanesListViewModel _airPlanesListViewModel;

        public AddPlaneCommand(AirPlanesListViewModel airplaneListViewModel)
        {
            _airPlanesListViewModel = airplaneListViewModel;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            var addPlaneWindow = new AddPlaneWindow();
            var viewModel = new AddPlaneViewModel();
            addPlaneWindow.DataContext = viewModel;
            var result = addPlaneWindow.ShowDialog();

            if(result == true)
                _airPlanesListViewModel.Airplanes.Add(MapToAirplane(viewModel));

            _airPlanesListViewModel.OnPropertyChanged();
        }

        private AirplaneViewModel MapToAirplane(AddPlaneViewModel viewModel)
        {
            return new AirplaneViewModel
            {
                Name = viewModel.Name,
                Producer = viewModel.Producer,
                IsNarrowBody = viewModel.IsNarrowBody,
                MaxPassengers = viewModel.MaxPassengers,
                MaxWeight = viewModel.MaxPassengers,
                FuelUsage = viewModel.FuelUsage
            };
        }

        public event EventHandler? CanExecuteChanged { add { } remove { } }
    }
}
