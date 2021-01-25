using EdutalkTeacherUWP.Home.Models;
using EdutalkTeacherUWP.Home.Params;
using EdutalkTeacherUWP.ViewModels;
using Microsoft.Toolkit.Uwp.UI.Animations;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EdutalkTeacherUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RoutesPage : Page
    {
        bool isScrolled { set; get; } = false;
        RoutesPageViewModel vm;
        public RoutesPage()
        {
            this.InitializeComponent();
            vm = (RoutesPageViewModel)DataContext;
        }

        private void Routes_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            if (isScrolled == false)
            {
                Routes.ScrollIntoView(vm.Routes.FirstOrDefault(c => c.IsPresent == true));
                isScrolled = true;
            }
        }

        private void Button_Click_Attendace(object sender, TappedRoutedEventArgs e)
        {
            var obj = (Border)sender;
            var dataContext = (RouteModel)obj.DataContext;
            SplitViewFrame.Navigate(typeof(AttendancePage), new ParamsAttendanceModel()
            {
                Route = dataContext,
                ClassroomId = dataContext.RouteType == RouteType.SupportClass ? (int)dataContext?.Id : (int)vm.Classroom?.Id
            });

        }
        private async void Cancel_Class_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await vm.CancelSupportClass();
        }

        private void Button_Click_Homework(object sender, TappedRoutedEventArgs e)
        {
            var obj = (Border)sender;
            var dataContext = (RouteModel)obj.DataContext;
            SplitViewFrame.Navigate(typeof(HomeworkPage), new ParamsAttendanceModel()
            {
                Route = dataContext,
                ClassroomId = (int)vm.Classroom?.Id
            });
        }
        private void Button_Click_Feedback(object sender, TappedRoutedEventArgs e)
        {
            var obj = (Border)sender;
            var dataContext = (RouteModel)obj.DataContext;
            SplitViewFrame.Navigate(typeof(FeedbackPage), new ParamsAttendanceModel()
            {
                Route = dataContext,
                ClassroomId = (int)vm.Classroom?.Id
            });
        }

        private async void Border_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (vm.Classroom.Mode == OnlineMode.Offline)
            {
                vm.Toast("Hiện tại không phải lớp Online");
                return;
            }

            await popupZoom.ShowAsync();

        }

        private void Button_Click_Create_AssistanceClass(object sender, TappedRoutedEventArgs e)
        {
            var obj = (Border)sender;
            var dataContext = (RouteModel)obj.DataContext;
            SplitViewFrame.Navigate(typeof(SupportClassPage), new SupportClassParams()
            {
                ClassroomId = vm.Classroom.Id,
                Lesson = dataContext.Lesson
            });
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var obj = (TextBox)sender;
            vm.ZoomId = obj.Text;
        }

        private async void popupRooms_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
           await vm.SettingZoom();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var obj = (PasswordBox)sender;
            vm.ZoomPassword = obj.Password;
        }
    }
}
