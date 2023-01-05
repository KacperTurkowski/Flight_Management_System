using FlightManagement.Base.ViewModels.Flights;
using System;
using System.Windows;
using System.Windows.Input;
using FlightManagement.Base.Authentication;
using FlightManagement.Base.Flights;
using FlightManagement.Base.Position;
using FlightManagement.ViewModelsFactories.Flights;

namespace FlightManagement.Flights
{
    public class OpenFlightWindowCommand : ICommand
    {
        private readonly FlightViewModel _viewModel;
        private readonly AccountDataProvider _accountDataProvider;

        public OpenFlightWindowCommand(FlightViewModel viewModel, AccountDataProvider accountDataProvider)
        {
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            _accountDataProvider = accountDataProvider ?? throw new ArgumentNullException(nameof(accountDataProvider));
        }
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is not FlightsList userControl ||
                userControl.DataContext is not IFlightCollection flightCollection) throw new ArgumentException();

            FlightViewModelFactory.Refresh(_viewModel);
            if (_viewModel.IsConfigured)
            {
                var window = new ConfiguredFlightWindow
                {
                    DataContext = _viewModel
                };
                var toRemove = window.ShowDialog();
                if (toRemove == true) DeleteFlight(flightCollection);
            }
            else
            {
                if (_accountDataProvider.Position == PositionEnum.Controller)
                {
                    var clone = _viewModel.Clone();
                    var window = new FlightConfigurationWindow()
                    {
                        DataContext = clone
                    };
                    var result = window.ShowDialog();
                    if(result == true)
                        SaveFlight(clone);
                }
                else
                {
                    var window = new NotConfiguredFlightAdminView()
                    {
                        DataContext = _viewModel
                    };
                    var toRemove = window.ShowDialog();
                    if(toRemove == true) DeleteFlight(flightCollection);
                }
            }
        }

        private void SaveFlight(FlightViewModel flightViewModel)
        {
            _viewModel.Airplane = flightViewModel.Airplane;
            _viewModel.Crew = flightViewModel.Crew;
            _viewModel.Pilot = flightViewModel.Pilot;
            _viewModel.TicketPrice = flightViewModel.TicketPrice;
            new FlightsRepository().FillFlight(_viewModel);
        }

        private void DeleteFlight(IFlightCollection flightCollection)
        {
            new FlightsRepository().DeleteFlight(_viewModel);
            flightCollection.Flights.Remove(_viewModel);
        }

        public event EventHandler? CanExecuteChanged{add{}remove{}}
    }
}
