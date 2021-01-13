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
    public sealed partial class AttendanceControl : UserControl
    {

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(string), typeof(AttendanceControl), new PropertyMetadata(null));

        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public static readonly DependencyProperty ColorBorderProperty = DependencyProperty.Register("ColorBorder", typeof(string), typeof(AttendanceControl), new PropertyMetadata(null));

        public string ColorBorder
        {
            get => (string)GetValue(ColorBorderProperty);
            set => SetValue(ColorBorderProperty, value);
        }


        public static readonly DependencyProperty TotalStudentProperty = DependencyProperty.Register("ColorBorder", typeof(string), typeof(AttendanceControl), new PropertyMetadata(null));

        public string TotalStudent
        {
            get => (string)GetValue(TotalStudentProperty);
            set => SetValue(TotalStudentProperty, value);
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("ColorBorder", typeof(string), typeof(AttendanceControl), new PropertyMetadata(null));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

         
        public AttendanceControl()
        {
            this.InitializeComponent();
        }
    }
}
