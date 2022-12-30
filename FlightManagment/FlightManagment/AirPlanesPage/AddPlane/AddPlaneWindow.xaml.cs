using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlightManagement.AirPlanesPage
{
    /// <summary>
    /// Interaction logic for AddPlaneWindow.xaml
    /// </summary>
    public partial class AddPlaneWindow : Window
    {
        private readonly Regex _regex = new Regex("[^0-9]+");

        public AddPlaneWindow()
        {
            InitializeComponent();
        }

        private void TextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = _regex.IsMatch(e.Text);
    }
}
