using EdutalkTeacherUWP.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Settings.Models
{
   public class ChangePasswordResult : ModelBase
    {
        public string Messenger { set; get; }
        public bool Success { set; get; }
    }
}
