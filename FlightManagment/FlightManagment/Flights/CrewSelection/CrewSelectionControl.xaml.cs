using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.Base.ViewModels.Flights;
using System.Windows;
using System.Windows.Controls;

namespace FlightManagement.Flights.CrewSelection
{
    /// <summary>
    /// Interaction logic for CrewSelectionControl.xaml
    /// </summary>
    public partial class CrewSelectionControl : UserControl
    {
        public CrewSelectionControl()
        {
            InitializeComponent();
        }

        private bool _lockSelectionChanged;

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_lockSelectionChanged)
                return;
            _lockSelectionChanged = true;
            var viewModel = (FlightViewModel)DataContext;
            var crewMember = (CrewMemberViewModel)comboBox.SelectedItem;
            viewModel.AvailableCrew.Remove(crewMember);
            viewModel.Crew.Add(crewMember);
            if (viewModel.Crew.Count == 6)
            {
                comboBox.Visibility = Visibility.Collapsed;
            }
            _lockSelectionChanged = false;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (FlightViewModel)DataContext;
            var crewMember = (CrewMemberViewModel)((Button)sender).DataContext;

            viewModel.Crew.Remove(crewMember);
            viewModel.AvailableCrew.Add(crewMember);
        }
    }
}
