using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.ClassDtos
{
    public class OffClassRequestDto
    {
        public long ClassroomId { get; set; }
        public int Lesson { get; set; }
        public string Action { get; set; } = "off";//on/off
    }
}
