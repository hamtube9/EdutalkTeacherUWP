using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Report.Models
{
    public class ReportModel
    {
        public AttendanceReportModel Attendance { set; get; }
        public TestReportModel[] Test { set; get; }
        public HomeWorkReportModel[] Homework { set; get; }
        public FeedbackReportModel[] Feedback { set; get; }

    }

    public class AttendanceReportModel
    {
        public long Off { set; get; }
        public long Attendance { set; get; }
        public long Total { set; get; }
    }

    public class TestReportModel
    {
        public long Level { set; get; }
        public long Total { set; get; }
        public long Count { set; get; }
        public string Description { set; get; }
    }

    public class HomeWorkReportModel
    {
        public long Level { set; get; }
        public long Total { set; get; }
        public long Count { set; get; }
        public string Description { set; get; }
    }
    public class FeedbackReportModel
    {
        public long Mark { set; get; }
        public long CountMark { set; get; }
        public long Total { set; get; }
    }

    public enum StateReport
    {
        Attendance, Test, Homework, Feedback
    }
}
