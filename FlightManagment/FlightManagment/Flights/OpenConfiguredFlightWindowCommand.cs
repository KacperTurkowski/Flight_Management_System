using FlightManagement.Base.ViewModels.Flights;
using System;
using System.Windows;
using System.Windows.Input;
using FlightManagement.Base.Authentication;
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
            _viewModel = viewModel;
            _accountDataProvider = accountDataProvider;
        }
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            FlightViewModelFactory.Refresh(_viewModel);
            if (_viewModel.IsConfigured)
            {
                if (_accountDataProvider.Position == PositionEnum.Controller)
                {
                    var window = new ConfiguredFlightWindow
                    {
                        DataContext = _viewModel
                    };
                    var toRemove = window.ShowDialog();
                    if (toRemove == true)
                    {
                        //usuwanie
                    }
                }
                else
                {
                    MessageBox.Show("Hello");
                }
            }
            else
            {
                var window = new FlightConfigurationWindow()
                {
                    DataContext = _viewModel
                };
                window.ShowDialog();
                //zapisywanie
            }
            
        }

        public event EventHandler? CanExecuteChanged{add{}remove{}}
    }
}
