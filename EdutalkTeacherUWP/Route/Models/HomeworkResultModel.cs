using EdutalkTeacherUWP.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Route.Models
{
    public class HomeworkResultModel  
    {
        public UserModel User { get; set; }
        public double Total { get; set; }
        public double Correct { get; set; }
    }

}
