using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace AirportClient.Convetors
{
    public class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((decimal)value == 0)
            {
                return String.Empty;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            decimal data;

            if (string.IsNullOrEmpty((string)value) || !decimal.TryParse((string)value, out data))
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
