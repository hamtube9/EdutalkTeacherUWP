using EdutalkTeacherUWP.Api.Authorization;
using EdutalkTeacherUWP.Api.Base;
using EdutalkTeacherUWP.Api.Dtos.ClassDtos;
using EdutalkTeacherUWP.Api.Extensions;
using EdutalkTeacherUWP.Api.Utils;
using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Common.Extensions;
using EdutalkTeacherUWP.Home.Models;
using EdutalkTeacherUWP.Settings.Service;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Home.Services
{
    public interface ISupportClassService
    {
        Task<RoomModel[]> GetRoomAsync(long classroomId, DateTime? date = null, double duration = 90);
        Task<UserModel[]> GetAllTutorAsync(long classId);
        Task<UserModel[]> GetStudentsAsync(long classroomId);
        Task<bool> CreateTutoringAsync(long classroom_id, string name, string note, long? roomId, DateTime date, UserModel[] students, string zoomId, string zoomPassword, OnlineMode mode, bool teacherHost, long? tutorId);

    }

    public class SupportClassService : ISupportClassService
    {
        
        readonly IApplicationSettings applicationSettings;
        readonly IAuthHeaderManager authHeader;
        readonly IApiBase apiBase;
        IEdutalkApi Api;
        public SupportClassService()
        {
            apiBase = new ApiBase();
            authHeader = new AuthHeaderManager();
            var token = authHeader.GetBearerToken().Result;
            applicationSettings = new ApplicationSettings();
            Api = RestService.For<IEdutalkApi>(new HttpClient(new AuthenticatedHttpClientHandler(() => authHeader.GetBearerToken())) { BaseAddress = new Uri(apiBase.ServerApi) }, RefitSetting.SnakeCaseNaming);

        }

        public async  Task<bool> CreateTutoringAsync(long classroom_id, string name, string note, long? roomId, DateTime date, UserModel[] students, string zoomId, string zoomPassword, OnlineMode mode, bool teacherHost, long? tutorId)
        {
            try
            {
                var result = await Api.CreateTutoring(
                    new CreateTutoringRequestDto
                    {
                        ClassroomId = classroom_id,
                        Date = date.ToString("yyyy-MM-dd"),
                        StartTime = date.TimeOfDay.ToString(),
                        EndTime = date.AddMinutes(90).TimeOfDay.ToString(),
                        Name = name,
                        Note = note,
                        RoomId = roomId,
                        CourseStudentIds = students.Select(d => d.Id).ToArray(),
                        ZoomId = zoomId,
                        ZoomPassword = zoomPassword,
                        FormStudy = mode == OnlineMode.Online ? "online" : "offline",
                        IsTeacher = teacherHost ? 1 : 0,
                        TrogiangId = tutorId
                    });
                return result.ToResult();
            }
            catch (Exception e)
            {

            }
            return false;
        }

        public async Task<UserModel[]> GetAllTutorAsync(long classId)
        {
            try
            {
                var result = await Api.GetAllTutor(classId);
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

        public  async Task<RoomModel[]> GetRoomAsync(long classroomId, DateTime? date = null, double duration = 90)
        {
            try
            {
                var result = date.HasValue ? await Api.GetRoom(classroomId, date.Value.ToString(AppContants.DateFormat), date.Value.ToString(AppContants.TimeFormat), date.Value.AddMinutes(duration).ToString(AppContants.TimeFormat)) : await Api.GetRoom(classroomId);

                if (result?.Data?.Length > 0)
                {
                    return result.Data.Select(d => d.ToModel()).ToArray();
                }
            }
            catch (Exception e)
            {
               

            }
            return new RoomModel[0];
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
    }
}
