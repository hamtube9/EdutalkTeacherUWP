using EdutalkTeacherUWP.Home.Models;
using EdutalkTeacherUWP.Settings.Service;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EdutalkTeacherUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudentSupportClassPage : Page
    {
        StudentSupportClassPageViewModel vm;
        IApplicationSettings applicationSettings;
        public StudentSupportClassPage()
        {
            this.InitializeComponent();
            vm = (StudentSupportClassPageViewModel)DataContext;
            applicationSettings = new ApplicationSettings();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if ((InfoStudentModel[])e.Parameter != null)
            {
                vm.Students = new System.Collections.ObjectModel.ObservableCollection<InfoStudentModel>((InfoStudentModel[])e.Parameter);
            }
        }
        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var obj = (Grid)sender;
            var data = (InfoStudentModel)obj.DataContext;
            vm.Students.FirstOrDefault(q => q.User.Id == data.User.Id).IsChoose = !data.IsChoose;
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var check = await applicationSettings.SetStudentSupportClass(vm.Students.ToArray());
            Frame.GoBack();
        }
    }
}
