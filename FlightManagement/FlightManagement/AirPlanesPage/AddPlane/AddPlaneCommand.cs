using System;
using System.Windows.Input;
using FlightManagement.Base.Airplanes;
using FlightManagement.Base.ViewModels.Airplane;
using FlightManagement.ViewModelsFactories.Airplane;

namespace FlightManagement.AirPlanesPage.AddPlane
{
    public class AddPlaneCommand : ICommand
    {
        private readonly AirPlanesListViewModel _airPlanesListViewModel;
        private readonly AirPlanesRepository _airPlanesRepository;

        public AddPlaneCommand(AirPlanesListViewModel airplaneListViewModel)
        {
            _airPlanesListViewModel = airplaneListViewModel;
            _airPlanesRepository = new AirPlanesRepository();
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            var addPlaneWindow = new AddPlaneWindow();
            var viewModel = AddPlaneViewModelFactory.Create();
            addPlaneWindow.DataContext = viewModel;
            var result = addPlaneWindow.ShowDialog();

            if (result == true)
            {
                var airplaneViewModel = MapToAirplane(viewModel);
                _airPlanesRepository.SaveAirPlane(airplaneViewModel);
                _airPlanesListViewModel.Airplanes.Add(airplaneViewModel);
            }

            _airPlanesListViewModel.OnPropertyChanged();
        }

        private AirplaneViewModel MapToAirplane(AddPlaneViewModel viewModel)
        {
            var result = AirplaneViewModelFactory.Create();
            result.Name = viewModel.Name;
            result.Producer = viewModel.Producer;
            result.IsNarrowBody = viewModel.IsNarrowBody;
            result.MaxPassengers = viewModel.MaxPassengers;
            result.MaxWeight = viewModel.MaxPassengers;
            result.FuelUsage = viewModel.FuelUsage;
            return result;
        }

        public event EventHandler? CanExecuteChanged { add { } remove { } }
    }
}
