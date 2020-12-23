using EdutalkTeacherUWP.Api.Dtos;
using EdutalkTeacherUWP.Api.Dtos.Authorizations;
using EdutalkTeacherUWP.Api.Dtos.ClassDtos;
using Refit;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Base
{
    public interface IEdutalkApi
    {
        [Post("/api/v3/mobile/login")]
        Task<SignInResultDto> SignIn([Body] SignInRequestDto request);

        //class 
        [Get("/api/v3/mobile/teacher/get-classroom")]
        Task<DataDto<ClassroomResultDto[]>> GetClassrooms();
    }
}
