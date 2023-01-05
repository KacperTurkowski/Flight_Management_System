using System.Collections.Generic;
using System.Collections.ObjectModel;
using FlightManagement.Base.Airplanes;
using FlightManagement.Base.Authentication;
using FlightManagement.Base.ViewModels.Airplane;
using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.Base.ViewModels.Flights;
using FlightManagement.Flights;
using FlightManagement.FlightsHistory;
using FlightManagement.ViewModelsFactories.Airplane;
using FlightManagement.ViewModelsFactories.Crew;

namespace FlightManagement.ViewModelsFactories.Flights
{
    public class FlightViewModelFactory
    {
        public static FlightViewModel Create(AccountDataProvider accountDataProvider)
        {
            var viewModel = new FlightViewModel();
            InitializeCommands(viewModel, accountDataProvider);
            viewModel.OpenFlightWindowCommand = new OpenFlightWindowCommand(viewModel, accountDataProvider);
            viewModel.Crew = new();
            return viewModel;
        }

        public static void Fill(FlightViewModel viewModel, AccountDataProvider accountDataProvider)
        {
            viewModel.Crew = new();
            InitializeCollections(viewModel);
            viewModel.OpenFlightWindowCommand = new OpenFlightWindowCommand(viewModel, accountDataProvider);
            InitializeCommands(viewModel, accountDataProvider);
        }

        public static void FillHistoryView(FlightViewModel viewModel, AccountDataProvider accountDataProvider)
        {
            viewModel.Crew = new();
            InitializeCollections(viewModel);
            viewModel.OpenFlightWindowCommand = new OpenFlightsHistoryInfoCommand(viewModel);
            InitializeCommands(viewModel, accountDataProvider);
        }

        private static void InitializeCollections(FlightViewModel viewModel)
        {
            var repository = new CrewMemberRepository();
            var pilots = repository.GetAllFreePilots(viewModel.StartDate);
            var stewards = repository.GetAllFreeStewards(viewModel.StartDate);
            var airplanes = new AirPlanesRepository().GetAirplanes();

            viewModel.AvailablePilots = new ObservableCollection<CrewMemberViewModel>();
            viewModel.AvailableCrew = new ObservableCollection<CrewMemberViewModel>();
            viewModel.AvailableAirplanes = new ObservableCollection<AirplaneViewModel>();
            

            foreach (var pilot in pilots)
            {
                var pilotViewModel = CrewMemberMapper.MapTo(pilot);
                CrewMemberViewModelFactory.Fill(pilotViewModel);
                viewModel.AvailablePilots.Add(pilotViewModel);
            }

            foreach (var steward in stewards)
            {
                var crewMemberViewModel = CrewMemberMapper.MapTo(steward);
                CrewMemberViewModelFactory.Fill(crewMemberViewModel);
                viewModel.AvailableCrew.Add(crewMemberViewModel);
            }

            foreach (var airplane in airplanes)
            {
                var airplaneViewModel = AirplaneMapper.MapTo(airplane);
                AirplaneViewModelFactory.Fill(airplaneViewModel);
                viewModel.AvailableAirplanes.Add(airplaneViewModel);
            }
        }

        private static void InitializeCommands(FlightViewModel viewModel, AccountDataProvider accountDataProvider)
        {
            viewModel.DeleteFlightCommand = new DeleteFlightCommand();
            viewModel.CloseAddFlightWindowCommand = new CloseAddFlightWindowCommand();
            viewModel.SaveConfigurationCommand = new SaveConfigurationCommand();
        }

        public static void Refresh(FlightViewModel viewModel)
        {
            InitializeCollections(viewModel);
        }
    }
}
