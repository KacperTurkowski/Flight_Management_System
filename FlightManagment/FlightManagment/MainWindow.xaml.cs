using System.Windows;
using FlightManagement.Authentication;
using FlightManagement.Base.Authentication;
using FlightManagement.Base.Position;
using FlightManagement.MainPage;
using FlightManagement.ViewModelsFactories;
using FlightManagement.ViewModelsFactories.Crew;

namespace FlightManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AccountDataProvider _accountDataProvider;
        public int SwitchView { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            _accountDataProvider = new AccountDataProvider();
        }


        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var authWindow = new AuthWindow
            {
                DataContext = AuthWindowViewModelFactory.Create(_accountDataProvider)
            };
            Hide();
            var loggingResult = authWindow.ShowDialog();

            if (loggingResult == true)
                Show();
            else
                Close();

            if (_accountDataProvider.Position == PositionEnum.Controller)
            {
                SwitchView = 0;
                DataContext = ControllerMainPageViewModelFactory.Create();
            }
            else
            {
                SwitchView = 1;
                DataContext = MainPageViewModelFactory.Create();
            }
                
            
        }
    }
}
