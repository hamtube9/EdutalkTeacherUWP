using EdutalkTeacherUWP.Common.Base;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public SettingsPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
    }
}
