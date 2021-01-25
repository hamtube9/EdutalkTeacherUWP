using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.ClassDtos
{
    public class LessonResultDto
    {
        public string Name { get; set; }
        public string Material { get; set; }
        public string Reading { get; set; }
        public string Speaking { get; set; }
        public string Writing { get; set; }
        public string Vocabulary { get; set; }
        public string Listening { get; set; }
        public string Grammar { get; set; }
        //public string self_study { get; set; }
        //public string exam { get; set; }
    }
}
