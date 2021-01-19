using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Settings.Service;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EdutalkTeacherUWP.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        IApplicationSettings applicationSettings;
        public UserModel User { set; get; }

        public SettingsPageViewModel(INavigationService navigationService  )
        {
            this.navigationService = navigationService;
            this.applicationSettings = new ApplicationSettings();
            SetData();
        }

        private void SetData()
        {
            User = applicationSettings.GetCurrentUser();
        }

        ICommand _loggoutCommand;
        public ICommand LoggoutCommand => _loggoutCommand = _loggoutCommand ?? new DelegateCommand(Logout);
        private void Logout()
        {
            navigationService.Navigate(PageTokens.Login.ToString(), null);
        }
    }
}
