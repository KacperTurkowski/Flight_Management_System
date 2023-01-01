using System.Windows;
using System.Windows.Controls;
using FlightManagement.Authentication;
using FlightManagement.Base.Authentication;
using FlightManagement.Base.ViewModels;
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

        public MainWindow()
        {
            InitializeComponent();
            _accountDataProvider = new AccountDataProvider();
            mainPage.DataContext = MainPageViewModelFactory.Create();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) => (sender as Button)!.Content = _accountDataProvider.Login;

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var authWindow = new AuthWindow
            {
                DataContext = AuthWindowViewModelFactory.Create(_accountDataProvider)
            };
            this.Hide();
            var loggingResult = authWindow.ShowDialog();
            
            if(loggingResult == true)
                this.Show();
            else
                this.Close();
        }
    }
}
