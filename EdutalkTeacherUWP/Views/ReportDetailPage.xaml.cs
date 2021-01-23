using EdutalkTeacherUWP.Home.Models;
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
    public sealed partial class ReportDetailPage : Page
    {
        ReportDetailPageViewModel vm;
        public ReportDetailPage()
        {
            this.InitializeComponent();
            vm = (ReportDetailPageViewModel)DataContext;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if ((ClassModel)e.Parameter != null)
            {
                vm.TimeStart = ((ClassModel)e.Parameter).StartDate;
                vm.ClassroomId = ((ClassModel)e.Parameter).Id;
                vm.SetData();
            }
        }
        private async void txtLesson_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await vm.ChangeStateLesson();
        }

        private async void txtMonth_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await vm.ChangeStateMonth();
        }

        private async void txtAll_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await vm.ChangeStateAll();
        }

        private void Image_Prev(object sender, TappedRoutedEventArgs e)
        {
            if (vm.PreLessonCommand.CanExecute(null))
            {
                vm.PreLessonCommand.Execute(null);
            }
        }

        private void Image_Next(object sender, TappedRoutedEventArgs e)
        {
            if (vm.NextLessonCommand.CanExecute(null))
            {
                vm.NextLessonCommand.Execute(null);
            }
        }
    }
}
