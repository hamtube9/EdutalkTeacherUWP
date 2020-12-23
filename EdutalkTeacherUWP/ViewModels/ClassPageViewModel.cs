using EdutalkTeacherUWP.Common.Base;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.ViewModels
{
   public class ClassPageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        public ClassPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
    }
}
