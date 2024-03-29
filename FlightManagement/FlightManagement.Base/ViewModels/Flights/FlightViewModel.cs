﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FlightManagement.Base.ViewModels.Airplane;
using FlightManagement.Base.ViewModels.Crew;

namespace FlightManagement.Base.ViewModels.Flights
{
    public class FlightViewModel : INotifyPropertyChanged
    {
        private CrewMemberViewModel? _pilot;
        private AirplaneViewModel _airplane;
        private int? _flightLength;
        private int? _airplaneId;
        private int _soldTickets;
        private int _soldCargo;
        private int? _ticketPrice;
        private DateTime _startDate = DateTime.Now;
        public string Title => string.Concat(StartAirport, "->",EndAirport);
        public string StartAirport { get; set; }
        public string EndAirport { get; set; }
        public string StartPlace { get; set; }
        public string EndPlace { get; set; }

        public int? FlightLength
        {
            get => _flightLength;
            set
            {
                if (value == _flightLength) return;
                if (value < 0)
                {
                    OnPropertyChanged();
                    return;
                }
                _flightLength = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(UsedFuel));
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (value.Equals(_startDate)) return;
                if (value.Date < DateTime.Now.Date)
                {
                    OnPropertyChanged();
                    return;
                }
                _startDate = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Date));
                OnPropertyChanged(nameof(Time));
            }
        }

        public AirplaneViewModel Airplane
        {
            get => _airplane;
            set
            {
                if (Equals(value, _airplane)) return;
                _airplane = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AirplaneName));
            }
        }

        public int? AirplaneId
        {
            get => _airplaneId;
            set
            {
                if (value == _airplaneId) return;
                if (value < 0)
                {
                    OnPropertyChanged();
                    return;
                }
                _airplaneId = value;
                OnPropertyChanged();
            }
        }

        public int SoldTickets
        {
            get => _soldTickets;
            set
            {
                if (value == _soldTickets) return;
                if (value < 0)
                {
                    OnPropertyChanged();
                    return;
                }
                _soldTickets = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Profit));
            }
        }

        public int SoldCargo
        {
            get => _soldCargo;
            set
            {
                if (value == _soldCargo) return;
                if (value < 0)
                {
                    OnPropertyChanged();
                    return;
                }
                _soldCargo = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Profit));
            }
        }

        public CrewMemberViewModel? Pilot
        {
            get => _pilot;
            set
            {
                if (Equals(value, _pilot)) return;
                _pilot = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PilotName));
                OnPropertyChanged(nameof(IsConfigured));
            }
        }

        public int? PilotId { get; set; }
        public ObservableCollection<CrewMemberViewModel> Crew { get; set; }

        public int? TicketPrice
        {
            get => _ticketPrice;
            set
            {
                if (value == _ticketPrice) return;
                if (value < 0)
                {
                    OnPropertyChanged();
                    return;
                }
                _ticketPrice = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Profit));
            }
        }


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
        public int UsedFuel => (FlightLength ?? 0) * Airplane?.FuelUsage ?? 0;
        public string AirplaneName => Airplane?.Name ?? string.Empty;
        public string PilotName => Pilot?.FullName ?? string.Empty;
        public bool IsConfigured => Pilot != null;
        public int CargoPrice => 1000;
        public int Profit => SoldCargo * CargoPrice + SoldTickets * (TicketPrice ?? 0) - UsedFuel * 10; 
        public ObservableCollection<CrewMemberViewModel> AvailablePilots { get; set; }
        public ObservableCollection<CrewMemberViewModel> AvailableCrew { get; set; }
        public ObservableCollection<AirplaneViewModel> AvailableAirplanes { get; set; }
        public int? ID { get; set; }
        public FlightViewModel()
        {
            for(int i=0;i<24;i++)
                Hours.Add(i.ToString("00"));

            for(int i=0;i<60;i++)
                Minutes.Add(i.ToString("00"));
        }

        public FlightViewModel Clone()
        {
            return new FlightViewModel()
            {
                Crew = new(),
                StartAirport = this.StartAirport,
                EndAirport = EndAirport,
                StartPlace = StartPlace,
                EndPlace = EndPlace,
                FlightLength = FlightLength,
                StartDate = StartDate,

                AvailableAirplanes = AvailableAirplanes,
                AvailableCrew = AvailableCrew,
                AvailablePilots = AvailablePilots,
                SaveConfigurationCommand = SaveConfigurationCommand
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
