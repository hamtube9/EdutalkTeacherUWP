using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.AuthorizationDtos
{
    public class VerifyPhoneResultDto
    {
        public string Pin { set; get; }
        public string Phone { set; get; }
        public bool Verified { set; get; }
        public int RemainingAttempts { set; get; }
    }
}
