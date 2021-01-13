using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace EdutalkTeacherUWP.Common.Converts
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value)
            {
                case string str:
                    return !string.IsNullOrEmpty(str);
                case double dou:
                    return dou > 0;
                case decimal dec:
                    return dec > 0;
                case int inte:
                    return inte > 0;
                case IEnumerable<object> lst:
                    return lst != null && lst.Count() > 0;
            }
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
