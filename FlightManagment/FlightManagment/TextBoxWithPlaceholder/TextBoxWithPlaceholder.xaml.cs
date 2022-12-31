using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FlightManagement.TextBoxWithPlaceholder
{
    /// <summary>
    /// Interaction logic for TextBoxWithPlaceholder.xaml
    /// </summary>
    public partial class TextBoxWithPlaceholder : TextBox
    {
        private bool _textWasChanged;

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(TextBoxWithPlaceholder),
                new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string Placeholder
        {
            get => (string) GetValue(PlaceholderProperty);
            set
            {
                SetValue(PlaceholderProperty, value);
                Text = value;
                Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        public TextBoxWithPlaceholder()
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

    }
}
