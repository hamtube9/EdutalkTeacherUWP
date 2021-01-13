using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.Exam
{
    public class ExamResultResultDto
    {
        public double Score { get; set; }
        public string Process { get; set; }
        public ExamResultDto Test { get; set; }
    }
}
