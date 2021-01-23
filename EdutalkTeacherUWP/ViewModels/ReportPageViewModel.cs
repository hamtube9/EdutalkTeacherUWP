using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Common.Util;
using EdutalkTeacherUWP.Home.Models;
using EdutalkTeacherUWP.Home.Services;
using EdutalkTeacherUWP.Report.Models;
using EdutalkTeacherUWP.Report.Service;
using EdutalkTeacherUWP.Views;
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
        IReportAllService reportAllService;
        ICourseService courseService;
        public DateTime StartTimeAll { set; get; }
        public List<ClassModel> Classes { set; get; }
        public ClassModel ClassSelected { set; get; }
        public int Month { set; get; }
        public int Year { set; get; }
        public string MonthCurrent => (Month + "/" + Year);
        public int Index { get; set; }
        public (int, int)[] ListMonthYear;
        public bool VisibleNext => ListMonthYear?.Length - 1 > Index;
        public bool VisiblePrev => 0 < Index;
        public ReportClassModel ReportClass { get; set; }
        public ReportFinanceModel ReportFinance { get; set; }
        public ReportFinanceTutorModel ReportFinanceTutor { get; set; }
        public string SchoolAttendanceRate { set; get; }
        public ReportPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            reportAllService = new ReportAllService();
            courseService = new CourseService();
            LoadClassAsync();
        }

        public async Task LoadClassAsync()
        {
            LoadMonth();
            var cl = await courseService.GetAllClassesAsync();
            if (cl == null)
            {
                return;
            }
            Classes = new List<ClassModel>(cl);
            if (Classes == null || Classes.Count > 0)
            {
                return;
            }
            StartTimeAll = Classes.OrderBy(d => d.StartDate).Select(d => d.StartDate).FirstOrDefault();
            Month = StartTimeAll.Month;
            Year = StartTimeAll.Year;
            await LoadReport();
        }

        void LoadMonth()
        {

            Month = StartTimeAll.Month;
            Year = StartTimeAll.Year;
            ListMonthYear = DateTimeUtil.GetAllMonths(Month, Year);
            if (ListMonthYear.Length >= 1)
                Index = ListMonthYear.Length - 1;
            SetMonth();
        }

        void SetMonth()
        {
            var current = ListMonthYear[Index];
            Month = current.Item2;
            Year = current.Item1;
        }

        public async void OnIndexChanged()
        {
            SetMonth();
            await LoadReport();
        }

        async Task LoadReport()
        {
            var data = await reportAllService.GetAllReportAsync(Month, Year);
            if (data != null)
            {
                ReportClass = data;
                SchoolAttendanceRate = ReportClass.SchoolAttendanceRate + "%";
            }
        }

        public void NextIndex()
        {
            Index++;
            OnIndexChanged();
        }

        public void PrevIndex()
        {
            Index--;
            OnIndexChanged();
        }

        public async Task ShowDetailReport()
        {
           var result = navigationService.Navigate(PageTokens.ReportDetail.ToString(), ClassSelected);
        }
    }
}
