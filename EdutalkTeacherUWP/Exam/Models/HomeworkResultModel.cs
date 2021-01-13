using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Exam.Models
{
    public class HomeworkResultModel : ModelBase
    {
        public UserModel User { get; set; }
        public double Total { get; set; }
        public double Correct { get; set; }
    }
}
