using System.Collections.ObjectModel;
using FlightManagement.AirPlanesPage;
using FlightManagement.Crew;

namespace FlightManagement.MainPage
{
    public class MainPageViewModel
    {
        public AirPlanesListViewModel AirPlanesListViewModel { get; set; }
        public CrewViewModel CrewViewModel { get; set; }
        public MainPageViewModel()
        {
            AirPlanesListViewModel = new AirPlanesListViewModel
            {
                Airplanes = new ObservableCollection<AirplaneViewModel>
                {
                    new AirplaneViewModel() { Name = "1" },
                    new AirplaneViewModel() { Name = "2" },
                    new AirplaneViewModel() { Name = "3" },
                }
            };
            CrewViewModel = new CrewViewModel();
        }
    }
}
