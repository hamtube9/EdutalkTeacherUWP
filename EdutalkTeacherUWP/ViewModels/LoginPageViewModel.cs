using EdutalkTeacherUWP.Authentication.Service;
using EdutalkTeacherUWP.Common.Base;
using Plugin.Toast;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EdutalkTeacherUWP.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public string Email { set; get; }
        public string Password { set; get; }
        IAuthenticationService service;
        private INavigationService _navigationService;
        public LoginPageViewModel(INavigationService _navigationService)
        {
            this._navigationService = _navigationService;
            service = new AuthenticationService();
            Email = "ngotriha02@gmail.com";
            Password = "123456";
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
        }

        ICommand _LoginAsyncCommand;
        public ICommand LoginAsyncCommand => _LoginAsyncCommand = _LoginAsyncCommand ?? new DelegateCommand(LoginAsync);

        private async void LoginAsync()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                Toast("Username or password cannot empty");
                return;
            }

            var result = await service.SignInAsync(Email, Password);
            if (result == true)
            {
                Toast("Success");
                var check = _navigationService.Navigate("Main", null);
            }
            else
            {
                Toast("False");
            }
        }
    }
}
