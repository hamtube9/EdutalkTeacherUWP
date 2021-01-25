using EdutalkTeacherUWP.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Home.Models
{
    public class LessonModel : ModelBase
    {
        public string Lesson { get; set; }
        public string Reading { get; set; }
        public string Speaking { get; set; }
        public string Writing { get; set; }
        public string Vocabulary { get; set; }
        public string Listening { get; set; }
        public string Material { get; set; }
        public string Grammar { get; set; }
    }
}
