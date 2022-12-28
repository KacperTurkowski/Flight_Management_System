using System.Collections.ObjectModel;
using FlightManagement.ViewModels.AirPlanesPage;

namespace FlightManagement.ViewModels.MainPage
{
    public class MainPageViewModel
    {
        public AirPlanesListViewModel AirPlanesListViewModel { get; set; }

        public MainPageViewModel()
        {
            AirPlanesListViewModel = new AirPlanesListViewModel
            {
                Airplanes = new ObservableCollection<Airplane>
                {
                    new Airplane() { Name = "1" },
                    new Airplane() { Name = "2" },
                    new Airplane() { Name = "3" },
                }
            };
        }
    }
}
