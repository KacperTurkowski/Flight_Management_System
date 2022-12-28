using System.Windows.Media;

namespace FlightManagement.ViewConstants
{
    public static class ColorStatic
    {
        public static Brush MainColor { get; set; } = new SolidColorBrush(Color.FromRgb(153, 185, 180));
        public static Brush SecondColor => new SolidColorBrush(Color.FromRgb(217, 217, 217));
    }
}
