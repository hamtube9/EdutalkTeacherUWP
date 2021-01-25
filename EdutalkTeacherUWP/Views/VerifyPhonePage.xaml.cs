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
        VerifyPhonePageViewModel vm;
        public VerifyPhonePage()
        {
            this.InitializeComponent();
             vm = (VerifyPhonePageViewModel)DataContext;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
          
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
              var result =   await binding.VerifyAsync();
                if (result)
                {
                    Frame.GoBack();
                }
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var binding = (VerifyPhonePageViewModel)this.DataContext;
            var result = await binding.VerifyAsync();
            if (result)
            {
                Frame.GoBack();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           var obj = (TextBox)sender;
            vm.PinCode = obj.Text;
        }
    }
}
