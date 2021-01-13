using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.ClassDtos
{
    public class ClassroomRequestDto
    {
        public long ClassroomId { get; set; }
    }
    public class ClassroomLessonRequestDto : ClassroomRequestDto
    {
        public int Lesson { get; set; }
    }

    public class SubmitAttendanceRequestDto : ClassroomLessonRequestDto
    {
        public long? TrogiangId { get; set; }
        public bool IsTeacher { get; set; }
        public AttendanceRequestDto[] Attendances { get; set; }
    }

    public class CourseStudentRequestDto
    {
        public long CourseStudentId { get; set; }
    }

    public class AttendanceRequestDto : CourseStudentRequestDto
    {
        public string Value { get; set; }
    }
}
