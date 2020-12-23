using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Home.Models;
using EdutalkTeacherUWP.Home.Services;
using EdutalkTeacherUWP.Settings.Service;
using Prism.Commands;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EdutalkTeacherUWP.ViewModels
{
    public class ClassPageViewModel : ViewModelBase
    {
        public bool IsRefreshing { get; set; }
        public List<ClassModel> Classes { get; set; }
        public UserModel User { get; set; }
        public bool HasNotification { get; set; }
        public ClassModel ClassSelected { set; get; }


        private readonly INavigationService navigationService;
        IApplicationSettings settings;
        ICourseService service;

        public ClassPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            SetData();
        }

        private void SetData()
        {
            settings = new ApplicationSettings();
            service = new CourseService();
            User = settings.CurrentUser;
            LoadClass();
        }

        async Task LoadClass()
        {
            var cl = await service.GetAllClassesAsync();
            if (cl == null || cl.Length == 0)
            {
                return;
            }
             
            Classes = new List<ClassModel>(cl);
        }

        ICommand _SelectCommand;
        public ICommand SelectCommand => _SelectCommand = _SelectCommand ?? new DelegateCommand<ClassModel>(ExcuteSelectCommand);
        async void ExcuteSelectCommand(ClassModel obj)
        {
            if (obj == null)
            {
                return;
            }

            if (User.AccountType == AccountType.Teacher)
            {
                 navigationService.Navigate(
                   PageTokens.Settings.ToString(),
                  obj);
            }
            else
            {
                navigationService.Navigate(
                     PageTokens.Settings.ToString(),
                    obj);
            }
        }
    }
}
