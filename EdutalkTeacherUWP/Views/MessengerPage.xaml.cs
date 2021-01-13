using EdutalkTeacherUWP.Message.Models;
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
    public sealed partial class MessengerPage : Page
    {
        MessengerPageViewModel binding;
        public MessengerPage()
        {
            this.InitializeComponent();
            binding = (MessengerPageViewModel)DataContext; if (binding == null)
            {
                return;
            }
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
       
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (binding == null)
            {

                return;
            }
            var check = binding.SelectedConversationCommand.CanExecute((ConversationModel)e.ClickedItem);
            if (check)
            {
                binding.SelectedConversationCommand.Execute((ConversationModel)e.ClickedItem);
            }
        }
    }
}
