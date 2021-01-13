using EdutalkTeacherUWP.Home.Models;
using EdutalkTeacherUWP.Home.Params;
using EdutalkTeacherUWP.ViewModels;
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

namespace EdutalkTeacherUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RoutesPage : Page
    {
        RoutesPageViewModel vm;
        public RoutesPage()
        {
            this.InitializeComponent();
            vm = (RoutesPageViewModel)DataContext;
        }

        private void Routes_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            Routes.ScrollIntoView(vm.Routes.FirstOrDefault(c => c.IsPresent == true));
        }

        private void Button_Click_Attendace(object sender, RoutedEventArgs e)
        {
            var obj = (Button)sender;
            var dataContext = (RouteModel)obj.DataContext;
            SplitViewFrame.Navigate(typeof(AttendancePage), new ParamsAttendanceModel()
            {
                Route = dataContext,
                ClassroomId = (int)vm.Classroom?.Id
            });

        }

        private void Button_Click_Homework(object sender, RoutedEventArgs e)
        {
            var obj = (Button)sender;
            var dataContext = (RouteModel)obj.DataContext;
            SplitViewFrame.Navigate(typeof(HomeworkPage), new ParamsAttendanceModel()
            {
                Route = dataContext,
                ClassroomId = (int)vm.Classroom?.Id
            });
        }
        private void Button_Click_Feedback(object sender, RoutedEventArgs e)
        {
            var obj = (Button)sender;
            var dataContext = (RouteModel)obj.DataContext;
        }

    }
}
