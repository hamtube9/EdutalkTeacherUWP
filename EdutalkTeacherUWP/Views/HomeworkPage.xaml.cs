using EdutalkTeacherUWP.Exam.Models;
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
    public sealed partial class HomeworkPage : Page
    {
        HomeworkPageViewModel vm;
        public HomeworkPage()
        {
            this.InitializeComponent();
            vm = (HomeworkPageViewModel)DataContext;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param = (ParamsAttendanceModel)e.Parameter;
            if (param != null)
            {
                vm.ClassroomId = param.ClassroomId;
                vm.Lesson = param.Route.Lesson;
                await vm.LoadAllStudent();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var obj = (Grid)sender;
            var binding = (HomeworkResultModel)obj.DataContext;
            //Frame.Navigate(typeof(ViewExamPage), new ViewHomeworkParam()
            //{
            //    ClassroomId = (int)vm?.ClassroomId,
            //    CourseStudentId = (int)binding.User.Id,
            //    IsHomework = true,
            //    Lesson = vm.Lesson
            //});
        }
    }
}
