using System.Collections.ObjectModel;
using System.Windows.Input;
using FlightManagement.Base.ViewModels.Airplane;
using FlightManagement.Base.ViewModels.Crew;

namespace FlightManagement.Base.ViewModels.Flights
{
    public class FlightViewModel
    {
        public string Title => string.Concat(StartAirport, "->",EndAirport);
        public string StartAirport { get; set; }
        public string EndAirport { get; set; }
        public string StartPlace { get; set; }
        public string EndPlace { get; set; }
        public int FlightLength { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public AirplaneViewModel Airplane { get; set; }
        public int? AirplaneId { get; set; }
        public int SoldTickets { get; set; }
        public int SoldCargo { get; set; }
        public CrewMemberViewModel? Pilot { get; set; }
        public int? PilotId { get; set; }
        public ObservableCollection<CrewMemberViewModel> Crew { get; set; }
        public int? TicketPrice { get; set; }
        

        
        public ICommand OpenFlightWindowCommand { get; set; }
        public ICommand CloseAddFlightWindowCommand { get; set; }
        public ICommand SaveConfigurationCommand { get; set; }
        public ICommand DeleteFlightCommand { get; set; }
        public List<string> Hours { get; set; } = new List<string>();
        public List<string> Minutes { get; set; } = new List<string>();
        public string Hour { get; set; }
        public string Minute { get; set; }

        public string Date => StartDate.ToShortDateString();
        public string Time => StartDate.ToShortTimeString();
        public string AirplaneName => Airplane?.Name ?? string.Empty;
        public string PilotName => Pilot.FullName;
        public bool IsConfigured => Pilot != null;
        public ObservableCollection<CrewMemberViewModel> AvailablePilots { get; set; }
        public ObservableCollection<CrewMemberViewModel> AvailableCrew { get; set; }
        public ObservableCollection<AirplaneViewModel> AvailableAirplanes { get; set; }
        public FlightViewModel()
        {
            for(int i=0;i<24;i++)
                Hours.Add(i.ToString("00"));

            for(int i=0;i<60;i++)
                Minutes.Add(i.ToString("00"));
        }
    }
}
