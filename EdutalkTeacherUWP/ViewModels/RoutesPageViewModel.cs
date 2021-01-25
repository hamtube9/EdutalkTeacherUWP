using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Home.Models;
using EdutalkTeacherUWP.Home.Services;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EdutalkTeacherUWP.ViewModels
{
    public class RoutesPageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        ICourseService courseService;
        public ClassModel Classroom { set; get; }
        public List<RouteModel> Routes { set; get; }
        RouteModel RouteSelected { set; get; }
        public ObservableCollection<AttendanceModel> Students { set; get; } = new ObservableCollection<AttendanceModel>();
        public bool IsVisibleAttendance { set; get; }
        public ScheduleModel Schedule { set; get; }
        public UserModel Tutor { set; get; }
        public bool AttendanceTutor { set; get; } = false;
        public UserModel[] Tutors { set; get; }
        public bool IsBusy { set; get; }
        public bool HasTutor { get; set; }
        public string ZoomId { set; get; }
        public string ZoomPassword { set; get; }
        public RoutesPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }


        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            courseService = new CourseService();
            Classroom = (ClassModel)e.Parameter != null ? (ClassModel)e.Parameter : null;
            IsBusy = true;
            await LoadRoutes();
            IsBusy = false;
        }

        public async Task LoadRoutes()
        {
            Schedule = await courseService.GetRoutesAsync((long)Classroom?.Id);
            if (Schedule == null)
            {
                return;
            }
            //IsEnableItemToobar = Schedule.Mode == OnlineMode.Online;
            Classroom.Mode = Schedule.Mode;
            Routes = new List<RouteModel>(Schedule.Routes);
        }


        bool IsSupportClass { set; get; }
        ICommand _AttendanceCommand;
        public ICommand AttendanceCommand => _AttendanceCommand = _AttendanceCommand ?? new Prism.Commands.DelegateCommand<RouteModel>(AttendanceStudent);
        private async void AttendanceStudent(RouteModel obj)
        {
            RouteSelected = obj;
            await LoadTutor();
            if (obj.RouteType == RouteType.SupportClass)
            {
                IsSupportClass = true;
                var result = await courseService.GetAttendancesAsync(Classroom.Id);
                if (result != null || result.Length > 0)
                {
                    Students = new ObservableCollection<AttendanceModel>(result);
                    IsVisibleAttendance = Students != null && Students.Count > 0 ? true : false;
                }
                return;
            }
            IsSupportClass = false;
            var students = await courseService.GetAttendancesAsync(obj.Lesson, Classroom.Id);
            if (students != null || students.Length > 0)
            {
                Students = new ObservableCollection<AttendanceModel>(students);
                IsVisibleAttendance = Students != null && Students.Count > 0 ? true : false;
            }
        }

        async Task LoadTutor()
        {
            Tutors = await courseService.GetAllTutorAsync(Classroom.Id);
            //AttendanceTutor = applicationSettings.CurrentUser?.AccountType == AccountType.Teacher && Tutors != null && Tutors.Length > 0 && Editable;
            if (Tutors?.Length > 0)
            {
                Tutor = Tutors.FirstOrDefault(d => d.Id == RouteSelected.AttendanceTutor || d.Id == RouteSelected.TutorId) ?? Tutors[0];
            }
        }
        ICommand _FeedbackCommand;
        public ICommand FeedbackCommand => _FeedbackCommand = _FeedbackCommand ?? new Prism.Commands.DelegateCommand<RouteModel>(FeedbackStudent);
        private void FeedbackStudent(RouteModel obj)
        {

        }


        ICommand _HomeworkCommand;
        public ICommand HomeWorkCommand => _HomeworkCommand = _HomeworkCommand ?? new Prism.Commands.DelegateCommand<RouteModel>(HomeWorkStudents);
        private void HomeWorkStudents(RouteModel obj)
        {

        }

        ICommand _SelectStudentCommand;
        public ICommand SelectStudentCommand => _SelectStudentCommand = _SelectStudentCommand ?? new Prism.Commands.DelegateCommand<AttendanceModel>(SelectStudent);
        private void SelectStudent(AttendanceModel obj)
        {
            switch (obj.Status)
            {
                case AttendanceStatus.A:
                    obj.Status = AttendanceStatus.P;
                    obj.IsAttendance = true;
                    break;
                default:
                    obj.Status = AttendanceStatus.A;
                    obj.IsAttendance = false;
                    break;
            }
        }

        public async Task CancelSupportClass()
        {
            var next = Routes.FirstOrDefault(d => d.RouteType != RouteType.SupportClass && d.Date > DateTime.Now);
            if (next == null)
            {
                return;
            }

            if (next.RouteType == RouteType.Exam)
            {

                IsBusy = true;
                var result = await courseService.OffClassAsync(next.Lesson, Classroom.Id);
                IsBusy = false;
                if (result)
                {
                    Toast("Thành công");
                    await LoadRoutes();
                }
                else
                {
                    Toast("Thất bại");
                }
            }
            else
            {

                IsBusy = true;
                var result = await courseService.OffClassAsync(next.Lesson, Classroom.Id);
                IsBusy = false;
                if (result)
                {
                    Toast("Thành công");
                    await LoadRoutes();
                }
                else
                {
                    Toast("Thất bại");
                }
            }
        }

        public async Task SettingZoom()
        {
            IsBusy = true;
            var result = await courseService.SetingZoomAsync(Classroom.Id, ZoomId, ZoomPassword);
            IsBusy = false;
            if (result == false)
            {
                Toast("Thiết lập thất bại");
            }
            else
            {
                Schedule.ZoomId = ZoomId;
                Schedule.ZoomPassword = ZoomPassword;
                Toast("Thiết lập thành công");
            }
        }
    }
}
