using EdutalkTeacherUWP.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Report.Models
{
    public class ReportClassModel : ModelBase
    {
        public string NumberOfClasses { get; set; }
        public string MediumScore { get; set; }
        public string SchoolAttendanceRate { get; set; }
        public string FeedbackNormal { get; set; } 
    }

    public class ReportAllModel : ModelBase
    {
        public ReportFinanceModel ReportFinance { get; set; }
        public ReportClassModel ReportClass { get; set; }
    }

    public class ReportFinanceModel : ModelBase
    {
        public string Revenue { get; set; }
        public string SalarySupporter { get; set; }
        public string ClassroomFees { get; set; }
        public string OtherFees { get; set; }
        public string Forfeit { get; set; }
        public string ExpectedProfit { get; set; }
        public string AmountReceived { get; set; }
    }

    public class ReportFinanceTutorModel : ModelBase
    {

    }
}
