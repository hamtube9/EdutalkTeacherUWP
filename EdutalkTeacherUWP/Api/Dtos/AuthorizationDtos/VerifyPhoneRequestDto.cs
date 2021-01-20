using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.AuthorizationDtos
{
    public class VerifyPhoneRequestDto : PhoneRequestDto
    {
        public string PinCode { set; get; }
    }
}
