using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace AirportClient.Convetors
{
    public class IntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            int data;

            if (string.IsNullOrEmpty((string)value) || !int.TryParse((string)value, out data))
            {
                return null;
            }
            else
            {
                return data;
            }
        }
    }
}
