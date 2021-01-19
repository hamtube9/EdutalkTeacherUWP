using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.ClassDtos
{
    public class TutoringRequestDto
    {
        public string Name { get; set; }
        public long? RoomId { get; set; }
        public string ZoomId { get; set; }
        public string ZoomPassword { get; set; }
        public string FormStudy { get; set; }
        public string Note { get; set; }
        public string Date { get; set; }
        public string EndTime { get; set; }
        public string StartTime { get; set; }
        public long[] CourseStudentIds { get; set; }



        public int IsTeacher { get; set; }
        public long? TrogiangId { get; set; }
    }

    public class CreateTutoringRequestDto : TutoringRequestDto
    {
        public long ClassroomId { get; set; }
    }

    public class UpdateTutoringRequestDto : TutoringRequestDto
    {
        public long Id { get; set; }
    }

    public class DeleteingRequestDto
    {
        public long Id { get; set; }
    }
}
