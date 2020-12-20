using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Base
{
    public interface IApiBase
    {
        string ServerApi { get; }
    }

    public class ApiBase : IApiBase
    {
        public const string BearerScheme = "Bearer";

        public string ServerApi => "https://api.edutalk.edu.vn";
    }

    public class BetaApiBase : IApiBase
    {
        public const string BearerScheme = "Bearer";

        public string ServerApi => "https://beta-api.edutalk.edu.vn";
    }
}
