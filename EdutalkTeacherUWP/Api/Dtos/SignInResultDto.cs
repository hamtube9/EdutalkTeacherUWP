using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos
{
    public class SignInResultDto
    {
        public string Token { get; set; }
        public UserResultDto User { get; set; }
    }
}
