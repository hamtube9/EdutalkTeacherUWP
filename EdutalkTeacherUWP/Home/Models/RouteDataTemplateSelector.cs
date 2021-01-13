using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace EdutalkTeacherUWP.Home.Models
{
    public class RouteDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Pass { get; set; }
        public DataTemplate Present { get; set; }
        public DataTemplate Future { get; set; }
        public DataTemplate Exam { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is RouteModel route)
            {
                switch (route.RouteType)
                {
                    case RouteType.Exam:
                        return Exam;
                    case RouteType.SupportClass:
                        if (route.Date > DateTime.Now)
                        {
                            return Future;
                        }
                        if (route.Date <= DateTime.Now && DateTime.Now <= route.End)
                        {
                            return Present;
                        }
                        return Pass;
                    case RouteType.Lesson:
                    default:
                        if (route.Next < DateTime.Now)
                        {
                            return Pass;
                        }
                        if (DateTime.Now >= route.Date && DateTime.Now <= route.Next)
                        {
                            return Present;
                        }
                        return Future;
                }
            }
            return Future;
        }
        
    }
}
