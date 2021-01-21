using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Home.Models
{
    public class CommentModel : ModelBase
    {
        public int Id { set; get; }
        public UserModel User { set; get; }
        public string Comment { set; get; }
    }
}
