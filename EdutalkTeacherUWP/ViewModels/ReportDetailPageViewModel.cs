using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Common.Util;
using EdutalkTeacherUWP.Home.Models;
using EdutalkTeacherUWP.Home.Services;
using EdutalkTeacherUWP.Report.Models;
using EdutalkTeacherUWP.Report.Service;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EdutalkTeacherUWP.ViewModels
{
    public class ReportDetailPageViewModel : ViewModelBase
    {
        public bool IsLesson { set; get; }
        public bool IsMonth { set; get; }
        public bool IsAll { set; get; } = true;
        public DateTime? TimeStart { get; set; }
        public int Month { set; get; }
        public int Year { get; set; }
        public int Lesson { get; set; }
        public int[] ListLesson { set; get; }
        public (int, int)[] ListMonthYear;
        public int Index { get; set; }
        public int IndexLesson { get; set; }
        public bool VisibleNext => (IsLesson == true && ListLesson?.Length - 1 > IndexLesson) || (IsMonth == true && ListMonthYear?.Length - 1 > Index);

        public bool VisiblePrev => (IsLesson == true && 0 < IndexLesson) || (IsMonth == true && 0 < Index);
        public string DateOrLesson => IsLesson == true ? ("Bài " + Lesson) : Month + "/" + Year;
        public long ClassroomId { set; get; }

        public ReportModel Report { set; get; }
        public List<ClassModel> Classes { get; set; }
        public List<RouteModel> Routes { get; set; }
        ScheduleModel Schedule { set; get; }
        IReportAllService reportAllService;
        ICourseService courseService;
        public ReportDetailPageViewModel()
        {
            reportAllService = new ReportAllService();
            courseService = new CourseService();
        }

        public async Task ChangeStateLesson()
        {
            if (IsLesson == true)
            {
                return;
            }
            IsLesson = true;
            IsMonth = false;
            IsAll = false;
            IndexLesson = ListLesson.Length - 1;
            SetLesson();
            await GetReport(ClassroomId, Lesson, null, null);
        }

        public async Task ChangeStateMonth()
        {
            if (IsMonth == true)
            {
                return;
            }
            IsLesson = false;
            IsMonth = true;
            IsAll = false;
            if (ListMonthYear == null)
            {
                Report = new ReportModel();
                return;
            }
            if (ListMonthYear.Length >= 1)
                Index = ListMonthYear.Length - 1;
            SetMonth();
            await GetReport(ClassroomId, null, Month, Year);
        }

        public async Task ChangeStateAll()
        {
            if (IsAll == true)
            {
                return;
            }
            IsLesson = false;
            IsMonth = false;
            IsAll = true;
            await Task.WhenAll(GetReport(ClassroomId, null, null, null), GetSchedule());
        }

        public async void SetData()
        {
            Month = TimeStart.Value.Month;
            Year = TimeStart.Value.Year;
            await Task.WhenAll(GetReport(ClassroomId, null, null, null), GetSchedule());
        }

        void SetMonth()
        {
            if (ListMonthYear.Length == 0)
            {
                return;
            }
            var current = ListMonthYear[Index];
            Month = current.Item2;
            Year = current.Item1;
        }
        void SetLesson()
        {
            if (ListLesson.Length > IndexLesson && IndexLesson > 0)
            {
                var current = ListLesson[IndexLesson];
                Lesson = current;
            }
        }

        public async Task GetSchedule()
        {
            ListMonthYear = DateTimeUtil.GetAllMonths(Month, Year);
            Schedule = await courseService.GetRoutesAsync(ClassroomId);
            if (Schedule != null)
                Routes = new List<RouteModel>(Schedule.Routes);
            ListLesson = Routes.Where(d => d.Date <= DateTime.Now).Select(d => d.Lesson).ToArray();
        }
        public async Task GetReport(long Id, int? lessson, int? month, int? year)
        {
            var data = await reportAllService.GetReportClassAsync(Id, lessson, month, year);
            if (data != null)
                Report = data;
        }

        ICommand _nextLessonCommand;
        public ICommand NextLessonCommand => _nextLessonCommand = _nextLessonCommand ?? new DelegateCommand(NextLesson);
        async void NextLesson()
        {
            if (IsLesson == true && IndexLesson < ListLesson.Length - 1)
            {
                IndexLesson++;
                SetLesson();
                await GetReport(ClassroomId, Lesson, null, null);
                return;
            }
            if (IsMonth == true && Index < ListMonthYear.Length - 1)
            {
                Index++;
                SetMonth();
                await GetReport(ClassroomId, null, Month, Year);
            }
        }

        ICommand _preLessonCommand;
        public ICommand PreLessonCommand => _preLessonCommand = _preLessonCommand ?? new DelegateCommand(PreLesson);
        async void PreLesson()
        {
            if (IsLesson == true && 0 < IndexLesson)
            {
                IndexLesson--;
                SetLesson();
                await GetReport(ClassroomId, Lesson, null, null);
                return;
            }
            if (IsMonth == true && 0 < Index)
            {
                Index--;
                SetMonth();
                  await GetReport(ClassroomId, null, Month, Year);
            }
        }
    }
}
