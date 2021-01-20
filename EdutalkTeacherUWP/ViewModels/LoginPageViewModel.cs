using EdutalkTeacherUWP.Api.Authorization;
using EdutalkTeacherUWP.Api.Extensions;
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
        public bool IsBusy { set; get; }
        IAuthenticationService service;
        private INavigationService _navigationService;
        public LoginPageViewModel(INavigationService _navigationService)
        {
            this._navigationService = _navigationService;
            service = new AuthenticationService();
        }

        ICommand _LoginAsyncCommand;
        public ICommand LoginAsyncCommand => _LoginAsyncCommand = _LoginAsyncCommand ?? new DelegateCommand(LoginAsync);

        private async void LoginAsync()
        {
            IsBusy = true;
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                Toast("Username or password cannot empty");
                IsBusy = false;
                return;
            }

            var result = await service.SignInAsync(Email, Password);
            if (result == true)
            {
                IsBusy = false;
                Toast("Đăng nhập thành công");
                var check = _navigationService.Navigate(PageTokens.Main.ToString(), null);
            }
            else
            {
                Toast("Đăng nhập thất bại");
                IsBusy = false;

            }
        }
    }
}
