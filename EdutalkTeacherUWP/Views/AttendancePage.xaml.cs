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
    public sealed partial class AttendancePage : Page
    {
        AttendancePageViewModel vm;
        public AttendancePage()
        {
            this.InitializeComponent();
            vm = (AttendancePageViewModel)DataContext;
            Students.ItemClick += Students_ItemClick;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param = (ParamsAttendanceModel)e.Parameter;
            if (param != null)
            {
                vm.ClassroomId = param.ClassroomId;
                vm.Route = param.Route;
                await vm.LoadAttendance();
            }
        }

        private void Submit_Attendance_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Attendance_Student_Click(object sender, RoutedEventArgs e)
        {
            var obj = (Grid)sender;
            var dataContext = (AttendanceModel)obj.DataContext;
            if (vm.SelectStudentCommand.CanExecute(dataContext))
            {
                vm.SelectStudentCommand.Execute(dataContext);
            }
        }

        private void Students_ItemClick(object sender, ItemClickEventArgs e)
        {
            var obj = (Button)sender;
            var dataContext = (AttendanceModel)obj.DataContext;
            if (vm.SelectStudentCommand.CanExecute(dataContext))
            {
                vm.SelectStudentCommand.Execute(dataContext);
            }
        }
    }


}
