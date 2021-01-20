using EdutalkTeacherUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class SettingsPage : Page
    {
        SettingsPageViewModel vm;
        public SettingsPage()
        {
            this.InitializeComponent();
            vm = (SettingsPageViewModel)DataContext;
        }



        private void NavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            vm.LoggoutCommand.Execute(null);
        }



        private void NavigationViewControl_PaneClosing(NavigationView sender, NavigationViewPaneClosingEventArgs args)
        {
            itemImage.Visibility = Visibility.Collapsed;
        }

        private void NavigationViewControl_PaneOpening(NavigationView sender, object args)
        {
            itemImage.Visibility = Visibility.Visible;
        }


        private async void itemImage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                var stream = await file.OpenStreamForReadAsync();
                await vm.UploadAvatar(stream);
            }
            else
            {
                Debug.WriteLine("cancel");
            }
        }

        private void NavigationViewItem_ChangePassword(object sender, TappedRoutedEventArgs e)
        {
            FrameContent.Navigate(typeof(ChangePasswordPage), null);
        }

        private async void NavigationViewItem_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            var uriBing = new Uri(@"https://api.edutalk.edu.vn/term-condition");

            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uriBing);
        }

      
    }
}
