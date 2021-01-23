using EdutalkTeacherUWP.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EdutalkTeacherUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var binding = (LoginPageViewModel)this.DataContext;
            var str = (PasswordBox)sender;
            if (binding != null)
            {
                binding.Password = str.Password;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var binding = (LoginPageViewModel)this.DataContext;
            var str = (TextBox)sender;
            if (binding != null)
            {
                binding.Email = str.Text;
            }
        }

        private async  void PasswordBox_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            var binding = (LoginPageViewModel)this.DataContext;
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                 binding.LoginAsyncCommand.Execute(null);
               
            }
        }
    }
}
