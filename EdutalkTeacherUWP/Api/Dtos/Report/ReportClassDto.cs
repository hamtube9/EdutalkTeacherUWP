using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.Report
{
    public class ReportClassDto
    {
        public AttendanceReportDto Attendance { set; get; }
        public TestReportDto[] Test { set; get; }
        public HomeWorkReportDto[] Homework { set; get; }
        public FeedbackReportDto[] Feedback { set; get; }
    }

    public class AttendanceReportDto
    {
        public long CoPhep { set; get; }
        public long CoMat { set; get; }
        public long Total { set; get; }
    }

    public class TestReportDto
    {
        public int Level { set; get; }
        public int Total { set; get; }
        public int Count { set; get; }
        public string Description { set; get; }
    }

    public class HomeWorkReportDto
    {
        public int Level { set; get; }
        public int Total { set; get; }
        public int Count { set; get; }
        public string Description { set; get; }
    }
    public class FeedbackReportDto
    {
        public long Mark { set; get; }
        public long CountMark { set; get; }
        public long Total { set; get; }
        public string Description { set; get; }
    }
}
