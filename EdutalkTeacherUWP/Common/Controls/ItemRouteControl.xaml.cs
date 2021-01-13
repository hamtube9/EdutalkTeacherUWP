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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EdutalkTeacherUWP.Common.Controls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ItemRouteControl : UserControl
    {
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(string), typeof(CircleImageControl), new PropertyMetadata(null));

        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public static readonly DependencyProperty ColorBorderProperty = DependencyProperty.Register("ColorBorder", typeof(string), typeof(CircleImageControl), new PropertyMetadata(null));

        public string ColorBorder
        {
            get => (string)GetValue(ColorBorderProperty);
            set => SetValue(ColorBorderProperty, value);
        }


        public static readonly DependencyProperty TotalStudentProperty = DependencyProperty.Register("ColorBorder", typeof(string), typeof(CircleImageControl), new PropertyMetadata(null));

        public string TotalStudent
        {
            get => (string)GetValue(TotalStudentProperty);
            set => SetValue(TotalStudentProperty, value);
        }

        public ItemRouteControl()
        {
            this.InitializeComponent();
        }
    }
}
