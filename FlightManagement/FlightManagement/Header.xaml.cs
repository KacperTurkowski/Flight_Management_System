using System.Windows;
using System.Windows.Controls;

namespace FlightManagement
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        public Visibility LogOutVisibility
        {
            get => Visibility.Collapsed;
            set
            {
                LogoutButton.Visibility = value;
            }
        }

        public Header()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)DataContext;
            mainWindow.Login();
        }
    }
}
