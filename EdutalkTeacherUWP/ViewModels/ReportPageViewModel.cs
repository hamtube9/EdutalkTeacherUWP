using EdutalkTeacherUWP.Common.Base;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.ViewModels
{
    public class ReportPageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public ReportPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
    }
}
