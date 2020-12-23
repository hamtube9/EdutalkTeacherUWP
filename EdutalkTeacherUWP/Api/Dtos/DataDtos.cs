using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos
{
    public class DataDto<T>
    {
        public T Data { set; get; }
    }

    public class ErrorResultDto<T>
    {
        public string Messages;
        public bool Error;
        public T Data { set; get; }
    }

    public class ErrorResultDto
    {
        public string Message;
        public bool? Errors;
    }

    public class ChangepassResultDto
    {
        public string Message;
        public bool? Error;
    }

    public class InformationResultDto
    {
        public bool? Error { get; set; }
        public string[] Messages { get; set; }
    }
}
