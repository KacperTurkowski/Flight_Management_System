using System.Windows;
using System.Windows.Controls;
using FlightManagement.Base.ViewModels.Crew;
using FlightManagement.Base.ViewModels.Flights;

namespace FlightManagement.Flights.CrewSelection
{
    /// <summary>
    /// Interaction logic for CrewSelectionCommand.xaml
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
    }
}
