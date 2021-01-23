using EdutalkTeacherUWP.Api.Authorization;
using EdutalkTeacherUWP.Api.Base;
using EdutalkTeacherUWP.Api.Extensions;
using EdutalkTeacherUWP.Api.Utils;
using EdutalkTeacherUWP.Common.Extensions;
using EdutalkTeacherUWP.Report.Models;
using EdutalkTeacherUWP.Settings.Service;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Report.Service
{
    public interface IReportAllService
    {
        Task<ReportClassModel> GetAllReportAsync(int month, int year);
        Task<ReportModel> GetReportClassAsync(long classId, int? lesson, int? month, int? year);
    }

    public class ReportAllService : IReportAllService
    {
        readonly IApplicationSettings applicationSettings;
        readonly IAuthHeaderManager authHeader;
        readonly IApiBase apiBase;
        IEdutalkApi Api;
        public ReportAllService()
        {
            apiBase = new ApiBase();
            authHeader = new AuthHeaderManager();
            var token = authHeader.GetBearerToken().Result;
            applicationSettings = new ApplicationSettings();
            Api = RestService.For<IEdutalkApi>(new HttpClient(new AuthenticatedHttpClientHandler(() => authHeader.GetBearerToken())) { BaseAddress = new Uri(apiBase.ServerApi) }, RefitSetting.SnakeCaseNaming);


        }
        public async Task<ReportClassModel> GetAllReportAsync(int month, int year)
        {
            try
            {
                var result = await Api.GetReportAllClass(month, year);
                if (result != null)
                {
                    return result?.ToModel();
                }
            }
            catch (Exception e)
            {
            }
            return new ReportClassModel();
        }

        public async Task<ReportModel> GetReportClassAsync(long classId, int? lesson, int? month, int? year)
        {
            try
            {
                var result = await Api.GetReportClass(classId, lesson, month, year);
                if (result != null)
                {
                    return result.ToModel();
                }
            }
            catch (Exception e)
            {

            }

            return null;
        }
    }
}
