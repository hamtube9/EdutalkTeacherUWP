using EdutalkTeacherUWP.Api.Dtos;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Base
{
    public interface IEdutalkApi
    {
        [Post("/api/v3/mobile/login")]
        Task<SignInResultDto> SignIn([Body] SignInRequestDto request);
    }
}
