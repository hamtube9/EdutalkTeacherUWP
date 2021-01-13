using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.ClassDtos
{
    public class TutoringResultDto : StudentResultDto
    {
        public string Attendance { get; set; }
        public string Feedback { get; set; }
    }
}
