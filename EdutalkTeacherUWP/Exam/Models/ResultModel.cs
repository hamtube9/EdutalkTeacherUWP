using EdutalkTeacherUWP.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Exam.Models
{
    public class ResultModel : ModelBase
    {
        public double TotalScore { get; set; }
        public int TotalQuestion { get; set; }
        public double Score { get; set; }
        public string Process { get; set; }
        public ExamModel Test { get; set; }
    }

    public class ExamModel : ModelBase
    {
        public long Id { get; set; }
        public int? Time { get; set; }
        public string TypeName { get; set; }
        public GroupQuestionModel[] Questions { get; set; }
    }
}
