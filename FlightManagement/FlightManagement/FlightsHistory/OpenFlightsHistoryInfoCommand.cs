using System;
using System.Windows.Input;
using FlightManagement.Base.ViewModels.Flights;

namespace FlightManagement.FlightsHistory
{
    public class OpenFlightsHistoryInfoCommand : ICommand
    {
        private readonly FlightViewModel _viewModel;

        public OpenFlightsHistoryInfoCommand(FlightViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            var window = new FlightsHistoryInfo()
            {
                DataContext = _viewModel
            };
            window.ShowDialog();
        }

        public event EventHandler? CanExecuteChanged{add{} remove{}}
    }
}
