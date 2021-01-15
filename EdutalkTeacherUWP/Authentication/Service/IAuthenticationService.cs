using EdutalkTeacherUWP.Api.Authorization;
using EdutalkTeacherUWP.Api.Base;
using EdutalkTeacherUWP.Api.Dtos.Authorizations;
using EdutalkTeacherUWP.Api.Utils;
using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Common.Extensions;
using EdutalkTeacherUWP.Settings.Service;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Authentication.Service
{
    public interface IAuthenticationService
    {
        //Task<bool> ForgotPasswordAsync(string email);
        //Task<bool> ChangePasswordForgot(string code, string password, string phone);
        Task<bool> SignInAsync(string userName, string password);
        //Task<bool> SignInWithGoogle(string idToken);
        //Task<bool> SignInWithFacebook(string accessToken);
        //Task<bool> SignUpAsync(string email, string fullName, string password, string phone);
        //Task<bool> LogoutAsync();
    }

    public class AuthenticationService : IAuthenticationService
    {
        readonly IApplicationSettings applicationSettings;
        readonly IAuthHeaderManager authHeader;
        readonly IApiBase apiBase;
        IEdutalkApi api;
        public AuthenticationService()
        {
            applicationSettings = new ApplicationSettings();
            authHeader = new AuthHeaderManager();
            apiBase = new ApiBase();

            api = RestService.For<IEdutalkApi>(new HttpClient(new HttpTracer.HttpTracerHandler()) { BaseAddress = new Uri(apiBase.ServerApi), Timeout = TimeSpan.FromSeconds(AppContants.TimeOut) }, RefitSetting.SnakeCaseNaming);

        }
        public async Task<bool> SignInAsync(string userName, string password)
        {
            try
            {
                var result = await api.SignIn(new SignInRequestDto()
                {
                    Email = userName,
                    Password = password
                });
                if (result != null)
                {
                    return await SetTokenAndUser(result);
                }
            }
            catch (Exception e)
            {

            }
            return false;
        }

        async Task<bool> SetTokenAndUser(SignInResultDto result)
        {
            if (string.IsNullOrEmpty(result?.Token))
            {
                return false;
            }
            var saveToken = await authHeader.SetAuthHeaderAsync(new Token { AccessToken = result.Token });
            if (!saveToken)
            {
                return false;
            }
            if (result.User == null)
            {
                return true;
            }


            var user = result.User;
            var boolSetting = applicationSettings.SetCurrentUser(user.ToModel());
            return true;
        }
    }
}
