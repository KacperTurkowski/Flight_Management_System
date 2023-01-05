using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FlightManagement.TextBoxWithPlaceholder
{
    /// <summary>
    /// Interaction logic for IntTextBox.xaml
    /// </summary>
    public partial class IntTextBox : TextBox
    {
        private readonly Regex _regex = new Regex("[^0-9]+");
        private bool _textWasChanged;

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(IntTextBox),
                new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set
            {
                SetValue(PlaceholderProperty, value);
                Text = value;
                Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        public IntTextBox()
        {
            InitializeComponent();
            GotFocus += GotFocus_Event;
            LostFocus += LostFocus_Event;
            Loaded += Loaded_Event;
        }

        private void Loaded_Event(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
            {
                Text = Placeholder;
                Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LostFocus_Event(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
            {
                Text = Placeholder;
                Foreground = new SolidColorBrush(Colors.Gray);
                _textWasChanged = false;
            }
            else
                _textWasChanged = true;
        }

        private void GotFocus_Event(object sender, RoutedEventArgs e)
        {
            if (Text == Placeholder && !_textWasChanged)
                Text = string.Empty;
            Foreground = new SolidColorBrush(Colors.Black);
        }

        private void IntTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length == 0)
                _textWasChanged = false;
            e.Handled = _regex.IsMatch(e.Text);
        }
    }
}
