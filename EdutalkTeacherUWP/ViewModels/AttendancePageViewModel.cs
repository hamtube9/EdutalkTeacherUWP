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
   public class AttendancePageViewModel : ViewModelBase
    {
        private readonly ICourseService courseService;

        public UserModel[] Tutors { set; get; }
        public UserModel Tutor { set; get; }
        public int ClassroomId { set; get; }
        public bool IsSupportClass { set; get; }
        public RouteModel Route { set; get; }
        public bool HasTutor { get; set; }
        public ObservableCollection<AttendanceModel> Students { set; get; }

        public AttendancePageViewModel()
        {
            courseService = new CourseService();
        }

        public async Task LoadAttendance()
        {

            await LoadTutor();
            if (Route.RouteType == RouteType.SupportClass)
            {
                IsSupportClass = true;
                var result = await courseService.GetAttendancesAsync(ClassroomId);
                if (result != null || result.Length > 0)
                {
                    Students = new ObservableCollection<AttendanceModel>(result);
                }
                return;
            }
            var students = await courseService.GetAttendancesAsync(Route.Lesson, Route.Id);
            if (students != null || students.Length > 0)
            {
                Students = new ObservableCollection<AttendanceModel>(students);
            }
            IsSupportClass = false;
        }


        private async Task LoadTutor()
        {
            Tutors = await courseService.GetAllTutorAsync(ClassroomId);
            //AttendanceTutor = applicationSettings.CurrentUser?.AccountType == AccountType.Teacher && Tutors != null && Tutors.Length > 0 && Editable;
            if (Tutors?.Length > 0)
            {
                Tutor = Tutors.FirstOrDefault(d => d.Id == Route.AttendanceTutor || d.Id == Route.TutorId) ?? Tutors[0];
            }
            HasTutor = Tutor != null ? true : false;
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

        ICommand _SubmitAttendanceCommand;
        public ICommand SubmitAttendanceCommand => _SubmitAttendanceCommand = _SubmitAttendanceCommand ?? new Prism.Commands.DelegateCommand(SubmitAttendance);

        private async void SubmitAttendance()
        {
            bool result;
            if (!IsSupportClass)
            {
                result = await courseService.AttendanceAsync(Students.ToArray(), Route.Lesson, ClassroomId, HasTutor ? Tutor?.Id : null);
            }
            else
            {
                result = await courseService.AttendanceTutoringAsync(Students.ToArray(), Route.Id, ClassroomId, HasTutor ? Tutor?.Id : null);
            }
        }
    }
}
