using EdutalkTeacherUWP.Api.Authorization;
using EdutalkTeacherUWP.Api.Base;
using EdutalkTeacherUWP.Api.Extensions;
using EdutalkTeacherUWP.Api.Utils;
using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Common.Extensions;
using EdutalkTeacherUWP.Exam.Models;
using EdutalkTeacherUWP.Settings.Service;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Exam.Service
{
  public  interface IExamService
    {
        Task<HomeworkResultModel[]> GetHomeworksAsync(int lesson, long classroomId);
        Task<ResultModel> GetResultAsync(int courseStudentId, long classroomId, int lesson, bool isHomeWork);
        Task<UserModel[]> GetStudentsAsync(long classroomId);
    }

    public class ExamService : IExamService
    {
        readonly IAuthHeaderManager authHeader;
        readonly IApiBase apiBase;
        IEdutalkApi Api;

        public ExamService()
        {
            apiBase = new ApiBase();
            authHeader = new AuthHeaderManager();
            var token = authHeader.GetBearerToken().Result;
            Api = RestService.For<IEdutalkApi>(new HttpClient(new AuthenticatedHttpClientHandler(() => authHeader.GetBearerToken())) { BaseAddress = new Uri(apiBase.ServerApi) }, RefitSetting.SnakeCaseNaming);

        }

        public async Task<HomeworkResultModel[]> GetHomeworksAsync(int lesson, long classroomId)
        {
            try
            {
                var result = await Api.GetHomework(classroomId, lesson, "homework");
                if (result?.Data?.Length > 0)
                {
                    return result.Data?.Select(d => d.ToHomeworkModel()).ToArray();
                }
            }
            catch (Exception e)
            {
            }
            return new HomeworkResultModel[0];
        }

        public async Task<UserModel[]> GetStudentsAsync(long classroomId)
        {
            try
            {
                var result = await Api.GetStudents(classroomId);
                if (result?.Data?.Length > 0)
                {
                    return result.Data.Select(d => d.ToModel()).ToArray();
                }
            }
            catch (Exception e)
            {
            }
            return new UserModel[0];
        }
        public async Task<ResultModel> GetResultAsync(int courseStudentId, long classroomId, int lesson, bool isHomeWork)
        {
            try
            {
                var result = await Api.GetResult(courseStudentId, classroomId, lesson, isHomeWork ? "homework" : "test");

                if (result == null || result.Data == null)
                {
                    return null;
                }

                var data = result.Data.ToModel();
               
                return data;
            }
            catch (Exception e)
            {
            }
            return null;
        }
    }
}
