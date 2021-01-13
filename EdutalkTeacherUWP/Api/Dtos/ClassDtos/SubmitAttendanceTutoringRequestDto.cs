using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.ClassDtos
{
    public class SubmitAttendanceTutoringRequestDto
    {
        public long Id { get; set; }
        public long? TrogiangId { set; get; }
        public AttendanceRequestDto[] Attendances { get; set; }
    }
}
