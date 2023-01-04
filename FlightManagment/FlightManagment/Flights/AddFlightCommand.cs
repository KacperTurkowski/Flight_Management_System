using System;
using System.Windows.Input;
using FlightManagement.Base.Flights;
using FlightManagement.Base.ViewModels.Flights;
using FlightManagement.ViewModelsFactories.Flights;

namespace FlightManagement.Flights
{
    public class AddFlightCommand : ICommand
    {
        private readonly FlightsListViewModel _flightsListViewModel;

        public AddFlightCommand(FlightsListViewModel flightsListViewModel)
        {
            _flightsListViewModel = flightsListViewModel;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            var window = new AddFlightWindow();
            var viewModel = FlightViewModelFactory.Create(_flightsListViewModel.AccountDataProvider);
            window.DataContext = viewModel;
            var result = window.ShowDialog();
            if (result == true)
            {
                new FlightsRepository().SaveFlight(viewModel);

                _flightsListViewModel.Flights.Add(viewModel);
                _flightsListViewModel.OnPropertyChanged(nameof(FlightsListViewModel.Flights));
            }

        }

        public event EventHandler? CanExecuteChanged { add{} remove{} }
    }
}
