using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Home.Models
{
   public class InfoStudentModel : ModelBase
    {
        public UserModel User { get; set; }
        public bool IsChoose { set; get; }
    }
}
