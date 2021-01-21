using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.ClassDtos
{
    public class SendFeedbackRequestDto : ClassroomLessonRequestDto
    {
        public FeedbackRequestDto[] ListFeedback { get; set; }
    }

    public class FeedbackRequestDto : CourseStudentRequestDto
    {
        public string Content { get; set; }
    }
}
