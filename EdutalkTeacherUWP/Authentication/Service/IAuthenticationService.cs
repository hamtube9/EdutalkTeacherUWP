using EdutalkTeacherUWP.Api.Authorization;
using EdutalkTeacherUWP.Api.Base;
using EdutalkTeacherUWP.Api.Utils;
using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Settings.Service;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
                var result = await api.SignIn(new Api.Dtos.SignInRequestDto()
                {
                    Email = userName,
                    Password = password
                });
                if(result != null)
                {
                    return true;
                }
            }
            catch(Exception e)
            {

            }
            return false;
        }
    }
}
