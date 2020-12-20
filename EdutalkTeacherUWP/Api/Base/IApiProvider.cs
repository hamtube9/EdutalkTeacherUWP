using EdutalkTeacherUWP.Api.Authorization;
using EdutalkTeacherUWP.Api.Extensions;
using EdutalkTeacherUWP.Api.Utils;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Base
{
    public interface IApiProvider<T>
    {
        T Api { get; }
    }

    public abstract class ApiProvider<T> : IApiProvider<T>
    {
        public T Api { get; private set; }

        public ApiProvider(IApiBase apiBase, RefitSettings setting)
        {
            Api = RestService.For<T>(apiBase.ServerApi, setting);
        }

        public ApiProvider(IApiBase apiBase)
        {
            Api = RestService.For<T>(apiBase.ServerApi);
        }
    }

    public class AuthApiProvider<T> : IApiProvider<T>
    {
        public T Api { get; private set; }

        public AuthApiProvider(IApiBase apiBase, IAuthHeaderManager authHeader, RefitSettings setting)
        {
            Api = RestService.For<T>(new HttpClient(new AuthenticatedHttpClientHandler(() => authHeader.GetBearerToken())) { BaseAddress = new Uri(apiBase.ServerApi) }, setting);
        }

        public AuthApiProvider(IApiBase apiBase, IAuthHeaderManager authHeader)
        {
            Api = RestService.For<T>(new HttpClient(new AuthenticatedHttpClientHandler(() => authHeader.GetBearerToken())) { BaseAddress = new Uri(apiBase.ServerApi) }, RefitSetting.SnakeCaseNaming);
        }
    }
}
