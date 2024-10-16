using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace Module07DataAccess.Converters
{
    public class EmployeeImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int employeeId)
            {
                string imageName = employeeId switch
                {
                    1 => "jerico.jpg",
                    2 => "alekz.jpg",
                    3 => "lucas.jpg",
                    4 => "elmalia.jpg",
                    5 => "joshua.jpg",
                    _ => "default.jpg"
                };
                return ImageSource.FromFile(imageName);
            }
            return ImageSource.FromFile("default.jpg");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}