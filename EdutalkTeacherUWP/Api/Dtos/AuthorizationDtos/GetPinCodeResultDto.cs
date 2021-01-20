using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.AuthorizationDtos
{
    public class GetPinCodeResultDto
    {
        public string PinCode { set; get; }
        public string TransId { set; get; }
        public int TotalSMS { set; get; }
        public int TotalPrice { set; get; }
    }
}
