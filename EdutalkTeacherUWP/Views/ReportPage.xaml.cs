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
    public sealed partial class ReportPage : Page
    {
        ReportPageViewModel vm;
        public ReportPage()
        {
            this.InitializeComponent();
            vm = (ReportPageViewModel)DataContext;
        }

        private void PrevTapped(object sender, TappedRoutedEventArgs e)
        {
            vm.PrevIndex();
        }
        private void NextTapped(object sender, TappedRoutedEventArgs e)
        {
            vm.NextIndex();
        }

        private void listRoom_ItemClick(object sender, ItemClickEventArgs e)
        {
            var obj = (ClassModel)e.ClickedItem;
            vm.ClassSelected = obj;
        }

        private async void ContentDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
         
        }

        private async void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            listRoom.ItemsSource = vm.Classes;
            await popupClass.ShowAsync();
        }

        private void popupClass_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var binding = (ReportPageViewModel)DataContext;
            ReportFrame.Navigate(typeof(ReportDetailPage), binding.ClassSelected);
        }
    }
}
