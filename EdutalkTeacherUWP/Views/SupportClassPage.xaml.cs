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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EdutalkTeacherUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SupportClassPage : Page
    {
        SupportClassPageViewModel vm;
        IApplicationSettings applicationSettings;
        public SupportClassPage()
        {
            this.InitializeComponent();
            vm = (SupportClassPageViewModel)DataContext;
            applicationSettings = new ApplicationSettings();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.NavigationMode == NavigationMode.New)
            {
                if ((SupportClassParams)e.Parameter != null)
                {
                    vm.ClassroomId = ((SupportClassParams)e.Parameter).ClassroomId;
                    vm.Lesson = ((SupportClassParams)e.Parameter).Lesson;
                    await vm.LoadRooms();
                    await vm.LoadTutor();
                    await vm.LoadStudent();
                    txtRoom.Text = vm.Room;
                    listRoom.ItemsSource = vm.Rooms;
                }
            }
            if (e.NavigationMode == NavigationMode.Back)
            {
                var dataStudent = applicationSettings.GetStudentSupportClass();
                vm.Students = new List<InfoStudentModel>(dataStudent.Where(q => q.IsChoose == true).ToList());
            }

        }
        private async void timePicker_SelectedTimeChanged(TimePicker sender, TimePickerSelectedValueChangedEventArgs args)
        {
            var date = vm?.Date;
            if (vm != null)
            {
                vm.Date = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, sender.Time.Hours, sender.Time.Minutes, sender.Time.Seconds);
                await vm.LoadRooms();
            }

        }

        private async void datePicker_SelectedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            var date = vm?.Date;
            if (vm != null)
            {
                vm.Date = new DateTime(sender.SelectedDate.Value.Year, sender.SelectedDate.Value.Month, sender.SelectedDate.Value.Day, date.Value.Hour, date.Value.Minute, date.Value.Second);
                await vm.LoadRooms();
            }

        }

        private async void Border_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (vm.IsOffline == false)
            {
                return;
            }
            await popupRooms.ShowAsync();
        }

        private void popupRooms_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            vm.Room = vm.Rooms.FirstOrDefault(c => c.IsSelected == true).Name;
            txtRoom.Text = vm.Room;
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var obj = (RoomModel)((TextBlock)sender).DataContext;
            vm.Rooms.FirstOrDefault(c => c.Name == obj.Name).IsSelected = true;
            foreach (var item in vm.Rooms)
            {
                if (item.Name != obj.Name)
                {
                    item.IsSelected = false;
                }
            }
        }

        private void listRoom_ItemClick(object sender, ItemClickEventArgs e)
        {
            var obj = (RoomModel)(e.ClickedItem);
            vm.Rooms.FirstOrDefault(c => c.Name == obj.Name).IsSelected = true;
            foreach (var item in vm.Rooms)
            {
                if (item.Name != obj.Name)
                {
                    item.IsSelected = false;
                }
            }
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(StudentSupportClassPage), vm.SourceStudents.ToArray());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var obj = (TextBox)sender;
            vm.Name = obj.Text;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = await vm.CreateSupportClass();
            if (result == true)
            {
                var obj = (RoutesPageViewModel)Frame.DataContext;
               await obj.LoadRoutes();
            }

        }
    }
}
