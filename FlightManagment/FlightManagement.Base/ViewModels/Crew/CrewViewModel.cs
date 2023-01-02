using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FlightManagement.Base.Position;

namespace FlightManagement.Base.ViewModels.Crew;

public class CrewViewModel : INotifyPropertyChanged
{
    private bool _isShowAllChecked;
    private bool _isPilotsChecked;
    private bool _isControllersChecked;
    private bool _isStewardsChecked;
    public event PropertyChangedEventHandler? PropertyChanged;
    public ObservableCollection<CrewMemberViewModel> CrewList { get; set; }
    public ObservableCollection<CrewMemberViewModel> FilteredCrewList => FilterCrewList();
    public ICommand AddCrewMemberCommand { get; set; }
    public ICommand OpenCrewMemberInfoCommand { get; set; }

    public bool IsShowAllChecked
    {
        get => _isShowAllChecked;
        set
        {
            if (value == _isShowAllChecked) return;
            _isShowAllChecked = value;
            IsPilotsChecked = value;
            IsControllersChecked = value;
            IsStewardsChecked = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(FilteredCrewList));
        }
    }

    public bool IsPilotsChecked
    {
        get => _isPilotsChecked;
        set
        {
            if (value == _isPilotsChecked) return;
            _isPilotsChecked = value;
            if (value == false)
            {
                _isShowAllChecked = false;
                OnPropertyChanged(nameof(IsShowAllChecked));
            }
            OnPropertyChanged();
            OnPropertyChanged(nameof(FilteredCrewList));
        }
    }

    public bool IsControllersChecked
    {
        get => _isControllersChecked;
        set
        {
            if (value == _isControllersChecked) return;
            _isControllersChecked = value;
            if (value == false)
            {
                _isShowAllChecked = false;
                OnPropertyChanged(nameof(IsShowAllChecked));
            }
            OnPropertyChanged();
            OnPropertyChanged(nameof(FilteredCrewList));
        }
    }

    public bool IsStewardsChecked
    {
        get => _isStewardsChecked;
        set
        {
            if (value == _isStewardsChecked) return;
            _isStewardsChecked = value;
            if (value == false)
            {
                _isShowAllChecked = false;
                OnPropertyChanged(nameof(IsShowAllChecked));
            }
            OnPropertyChanged();
            OnPropertyChanged(nameof(FilteredCrewList));
        }
    }

    public CrewViewModel()
    {
        CrewList = new ObservableCollection<CrewMemberViewModel>();
        IsShowAllChecked = true;
    }
    public virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public ObservableCollection<CrewMemberViewModel> FilterCrewList()
    {
        var result = new ObservableCollection<CrewMemberViewModel>();
        foreach (var crewMemberViewModel in CrewList)
        {
            if (!crewMemberViewModel.IsActive)
                continue;
            if (IsShowAllChecked)
            {
                result.Add(crewMemberViewModel);
                continue;
            }

            if (crewMemberViewModel.PositionEnum == PositionEnum.Controller && IsControllersChecked)
            {
                result.Add(crewMemberViewModel);
                continue;
            }
            if (crewMemberViewModel.PositionEnum == PositionEnum.Pilot && IsPilotsChecked)
            {
                result.Add(crewMemberViewModel);
                continue;
            }
            if (crewMemberViewModel.PositionEnum == PositionEnum.Steward && IsStewardsChecked)
                result.Add(crewMemberViewModel);
        }

        return result;
    }
}