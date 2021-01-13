using EdutalkTeacherUWP.Home.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace EdutalkTeacherUWP.Common.Controls
{
    public sealed partial class RouteControl : UserControl
    {
        public static readonly DependencyProperty RouteProperty = DependencyProperty.Register("Route", typeof(RouteModel), typeof(RouteControl), new PropertyMetadata(null));

        public RouteModel Route
        {
            get => (RouteModel)GetValue(RouteProperty);
            set => SetValue(RouteProperty, value);
        }
       

        public string TimeStudy { set; get; }
        public string ImageCloud { set; get; }

        public string ColorBrush { set; get; }
        public string BackgroundText { set; get; }
        public RouteControl()
        {
            this.InitializeComponent();
            SetData();
        }

        private void SetData()
        {
           
            if (Route == null)
            {
                return;
            }
            SetBackGround();
            var minStart = Route.Date.Minute != 0 ? $"{Route.Date.Minute}" : "";
            var minEnd = Route.End.Minute != 0 ? $"{Route.End.Minute}" : "";
            TimeStudy = $"{Route.Date.Hour}h{minStart}-{Route.End.Hour}h{minEnd}";
        }

        private void SetBackGround()
        {
            if (Route.Date < DateTime.Now)
            {
                ImageCloud = "/Assets/ic_cloud_green.png";
                ColorBrush = "#1EA218";
                BackgroundText = "#E4F2DF";
            }
            var days = (Route.Next - Route.Date).Days;
            if (Route.Date >= DateTime.Now.AddDays(days))
            {
                ImageCloud = "/Assets/ic_cloud_white.png";
                ColorBrush = "#31428D";
                BackgroundText = "#D1E3F2";
            }

            if (Route.Date > DateTime.Now)
            {
                ImageCloud = "/Assets/ic_cloud_white.png";
                ColorBrush = "#707070";
                BackgroundText = "#D1E3F2";
            }
        }
    }
}
