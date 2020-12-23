using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Route.Models;
using EdutalkTeacherUWP.Route.Service;
using EdutalkTeacherUWP.Settings.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Route.VIewModels
{
    public class ClassViewModel : ViewModelBase
    {
        public List<ClassModel> Classes { get; set; }

        public UserModel User { get; set; }
        public bool HasNotification { get; set; }

         ICourseService courseService;
         IApplicationSettings applicationSettings;
        // INotificationService notificationService;

        public ClassViewModel()
        {
            courseService = new CourseService();
            applicationSettings = new ApplicationSettings();

            LoadData();
        }

        private void LoadData()
        {

        }
    }
}
