using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Exam.Models
{
   public class ViewHomeworkParam
    {
        public int Lesson { set; get; }
        public int ClassroomId { set; get; }
        public bool IsHomework { set; get; }
        public int CourseStudentId { set; get; }
    }
}
