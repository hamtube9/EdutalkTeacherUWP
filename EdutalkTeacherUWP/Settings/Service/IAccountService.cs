using EdutalkTeacherUWP.Api.Authorization;
using EdutalkTeacherUWP.Api.Base;
using EdutalkTeacherUWP.Api.Dtos.AuthorizationDtos;
using EdutalkTeacherUWP.Api.Extensions;
using EdutalkTeacherUWP.Api.Utils;
using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Common.Extensions;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Settings.Service
{
    public interface IAccountService
    {
        Task<UserModel> UploadProfileImageAsync(Stream str, string name);
        Task<UserModel> GetCurrentUserAsync();
        Task<bool> GetPinCodeVerify(string phone);
        Task<bool> VerifyPhone(VerifyPhoneRequestDto request);
        Task<bool> ChangePasswordAsync(string oldpassword, string newpassword);
    }

    public class AccountService : IAccountService
    {
        readonly IApplicationSettings applicationSettings;
        readonly IAuthHeaderManager authHeader;
        readonly IApiBase apiBase;
        IEdutalkApi Api;

        public AccountService()
        {
            apiBase = new ApiBase();
            authHeader = new AuthHeaderManager();
            var token = authHeader.GetBearerToken().Result;
            applicationSettings = new ApplicationSettings();
            Api = RestService.For<IEdutalkApi>(new HttpClient(new AuthenticatedHttpClientHandler(() => authHeader.GetBearerToken())) { BaseAddress = new Uri(apiBase.ServerApi) }, RefitSetting.SnakeCaseNaming);

        }
        public async Task<bool> ChangePasswordAsync(string oldpassword, string newpassword)
        {
            return false;
        }

        public async Task<UserModel> GetCurrentUserAsync()
        {
            return null;
        }

        public async Task<bool> GetPinCodeVerify(string phone)
        {
            return false;
        }

        public async Task<UserModel> UploadProfileImageAsync(Stream str, string name)
        {
            try
            {
                var result = await Api.UpdateProfileUploadProfileImage(new StreamPart(str, name ?? "file.png"));
                return result?.User?.ToModel();
            }
            catch (Exception e)
            {
            }
            return null;
        }

        public async Task<bool> VerifyPhone(VerifyPhoneRequestDto request)
        {
            return false;
        }
    }
}
