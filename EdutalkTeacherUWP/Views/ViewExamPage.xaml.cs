using EdutalkTeacherUWP.Exam.Models;
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
    public sealed partial class ViewExamPage : Page
    {
        ViewExamPageViewModel vm;
        public ViewExamPage()
        {
                this.InitializeComponent();
            vm = new ViewExamPageViewModel();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param = (ViewHomeworkParam)e.Parameter;
            if (param != null)
            {
                await vm.LoadHomework(param.CourseStudentId, param.ClassroomId,param.Lesson,param.IsHomework);
            }
        }
    }
}
