using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.AuthorizationDtos
{
    public class UpdatePasswordRequestDto
    {
        public string PasswordOld { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
