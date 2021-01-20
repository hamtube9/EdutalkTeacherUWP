using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.AuthorizationDtos
{
    public class AccountUserResultDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AvatarResultDto Avatar { get; set; }
    }

    public class AvatarResultDto
    {
        public string Path { get; set; }
    }
}
