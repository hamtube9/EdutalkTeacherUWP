using EdutalkTeacherUWP.Message.Models;
using EdutalkTeacherUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
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
    public sealed partial class ConversationPage : Page
    {
        ConversationPageViewModel vm;
        public ConversationPage()
        {
            this.InitializeComponent();
            vm = (ConversationPageViewModel)DataContext;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if ((ParamConversationModel)e.Parameter != null)
            {
                vm?.SetData(((ParamConversationModel)e.Parameter).Messages);
                vm.ConversationId = ((ParamConversationModel)e.Parameter).ConversationId;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var obj = (TextBox)sender;
            vm.Message = obj.Text;
        }

        private async void Border_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var result = await vm.SendMessageAsync();
            if (result)
            {
                txtMessage.Text= string.Empty;
            }
        }

        private async void txtMessage_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            var messVM = (MessengerPageViewModel)Frame.DataContext;

            if (e.Key == VirtualKey.Control || e.Key == VirtualKey.Shift)
            {
                txtMessage.AcceptsReturn = true;
            }
            else if (e.Key == Windows.System.VirtualKey.Enter)
            {
                var result = await vm.SendMessageAsync();
                if (result)
                {
                    txtMessage.Text = string.Empty;
                    await messVM.LoadConversation();
                }
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
         
        }

     

        private void txtMessage_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Control || e.Key == VirtualKey.Shift)
            {
                txtMessage.AcceptsReturn = false;
            }
        }
    }
}
