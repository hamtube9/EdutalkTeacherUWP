using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.ClassDtos
{
    public class AttendanceResultDto : StudentResultDto
    {
        public string Value { get; set; }
    }

    public class FeedbackResultDto : StudentResultDto
    {
        public string Content { get; set; }
    }

    public class StudentResultDto
    {
        public long Id { get; set; }
        public long UserId { set; get; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }
    }
}
