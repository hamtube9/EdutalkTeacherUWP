using EdutalkTeacherUWP.Authentication.Service;
using EdutalkTeacherUWP.Common.Base;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EdutalkTeacherUWP.Authentication.ViewModels
{
    public class LoginViewModel :ViewModelBase
    {
        public string Username { set; get; }
        public string Password { set; get; }
        IAuthenticationService service;
        public LoginViewModel()
        {
            service = new AuthenticationService();
            Username = "edutalk.room5@gmail.com";
            Password = "123456";
        }

        ICommand _LoginAsyncCommand;
        public ICommand LoginAsyncCommand => _LoginAsyncCommand = _LoginAsyncCommand ?? new DelegateCommand(LoginAsync);

        private async void LoginAsync()
        {
            if(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                Toast("Username or password cannot empty");
                return;

            }

            var result = await service.SignInAsync(Username, Password);
            if (result == true)
            {
                Toast("Success");
            }
            else
            {
                Toast("False");
            }
        }
    }
}
