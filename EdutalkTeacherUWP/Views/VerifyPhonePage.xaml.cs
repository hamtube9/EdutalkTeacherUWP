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
    public sealed partial class VerifyPhonePage : Page
    {
        public VerifyPhonePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var vm = (VerifyPhonePageViewModel)DataContext;
            if (!string.IsNullOrEmpty((string)e.Parameter))
            {
                vm.Phone = (string)e.Parameter;
            }
        }
        private async void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            var binding = (VerifyPhonePageViewModel)this.DataContext;
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
               await binding.VerifyAsync();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
