using EdutalkTeacherUWP.Api.Authorization;
using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Settings.Service;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

namespace EdutalkTeacherUWP.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        IApplicationSettings applicationSettings;
        IAccountService accountService;
        public UserModel User { set; get; }
        public string Version { set; get; }

        public SettingsPageViewModel(INavigationService navigationService  )
        {
            this.navigationService = navigationService;
            this.applicationSettings = new ApplicationSettings();
            accountService = new AccountService();
            SetData();
        }

        private void SetData()
        {
            User = applicationSettings.GetCurrentUser();
            Version = $"AppVersion {AppInfo.VersionString}";
        }

        ICommand _loggoutCommand;
        public ICommand LoggoutCommand => _loggoutCommand = _loggoutCommand ?? new DelegateCommand(Logout);
        private void Logout()
        {
            var authHeader = new AuthHeaderManager();
            authHeader.SetAuthHeaderAsync(string.Empty);
            applicationSettings.SetCurrentUser(new UserModel());
            navigationService.Navigate(PageTokens.Login.ToString(), null);
        }

        public async Task UploadAvatar(Stream str)
        {
            var result = await accountService.UploadProfileImageAsync(str, "user-" + (User?.Code ?? "avatar") + ".png");
            User = result;
            applicationSettings.SetCurrentUser(result);
        }
    }
}
