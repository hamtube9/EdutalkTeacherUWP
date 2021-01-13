using EdutalkTeacherUWP.Api.Dtos.ClassDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.Exam
{
    public class HomeworkResultDto : StudentResultDto
    {
        public HomeworkScoreResultDto Test { get; set; }
    }

    public class HomeworkScoreResultDto
    {
        public double Score { get; set; }

        public double Total { get; set; }
    }
}
