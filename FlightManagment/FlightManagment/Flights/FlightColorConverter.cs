using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media;
using FlightManagement.ViewConstants;

namespace FlightManagement.Flights;

[ValueConversion(typeof(bool), typeof(Brush))]
internal class FlightColorConverter : IValueConverter
{

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (bool)value == true ? new SolidColorBrush(Colors.Gray) : new SolidColorBrush(Colors.DarkGray);

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => true;
}