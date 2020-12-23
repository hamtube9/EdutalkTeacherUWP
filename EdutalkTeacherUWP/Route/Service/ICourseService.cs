using EdutalkTeacherUWP.Api.Authorization;
using EdutalkTeacherUWP.Api.Base;
using EdutalkTeacherUWP.Api.Utils;
using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Route.Models;
using EdutalkTeacherUWP.Settings.Service;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Route.Service
{
    public interface ICourseService
    {
        //Task<HomeworkResultModel[]> GetMarksAsync(int lesson, long classroomId);
        //Task<HomeworkResultModel[]> GetHomeworksAsync(int lesson, long classroomId);
        //Task<CommentModel[]> GetFeedbacksAsync(int lesson, long classroomId);
        //Task<AttendanceModel[]> GetAttendancesAsync(int lesson, long classroomId);
        //Task<UserModel[]> GetStudentsAsync(long classroomId);
        Task<ClassModel[]> GetAllClassesAsync();
        //Task<bool> AttendanceAsync(AttendanceModel[] attendance, int lesson, long classroomId, long? tutorId);
        //Task<bool> FeedbackAsync(CommentModel[] comments, int lesson, long classroomId);
        //Task<ScheduleModel> GetRoutesAsync(long classroomId);
        //Task<ScheduleModel> GetRoutesAsync(long classroomId, long tutorId);
        //Task<bool> OffClassAsync(int lesson, long classroomId);
        //Task<LessonModel> GetLessonAsync(int lesson, long classroomId);

        //Task<bool> SetingZoomAsync(long idclas, string zoomid, string zoompassword);
        //Task<UserModel[]> GetAllTutorAsync(long classId);
    }

    public class CourseService :   ICourseService
    {
        readonly IApplicationSettings applicationSettings;
        readonly IAuthHeaderManager authHeader;
        readonly IApiBase apiBase;
        IEdutalkApi api;

        public CourseService()
        {
            applicationSettings = new ApplicationSettings();
            authHeader = new AuthHeaderManager();
            apiBase = new ApiBase();

            api = RestService.For<IEdutalkApi>(new HttpClient(new HttpTracer.HttpTracerHandler()) { BaseAddress = new Uri(apiBase.ServerApi), Timeout = TimeSpan.FromSeconds(AppContants.TimeOut) }, RefitSetting.SnakeCaseNaming);

        }

        //public async Task<bool> AttendanceAsync(AttendanceModel[] students, int lesson, long classroomId, long? tutorId)
        //{
        //    try
        //    {
        //        var result = await Api.SubmitAttendance(new SubmitAttendanceRequestDto
        //        {
        //            TrogiangId = tutorId,
        //            Lesson = lesson,
        //            ClassroomId = classroomId,
        //            Attendances = students.Select(d => new AttendanceRequestDto
        //            {
        //                CourseStudentId = d.User.Id,
        //                Value = d.Status.ToString()
        //            }).ToArray()
        //        });

        //        return result.ToResult();
        //    }
        //    catch (Exception e)
        //    {
        //        logService.Log(e, new Dictionary<string, string>() { { $"Attendance student error . classroom id {classroomId}, lesson {lesson}, tutor id :{tutorId}", e.Message } });
        //    }
        //    return false;
        //}

        //public async Task<bool> SetingZoomAsync(long idclass, string zoomid, string zoompassword)
        //{
        //    try
        //    {
        //        var result = await Api.SetingZoom(new ApiModule.Dtos.Zoom.SettingZoomRequestDto()
        //        {
        //            ZoomPassword = zoompassword,
        //            Id = idclass,
        //            ZoomId = zoomid
        //        });
        //        return result?.Error == false;
        //    }
        //    catch (Exception e)
        //    {
        //        logService.Log(e, new Dictionary<string, string>() { { $"Setting zoom error . classroom id {idclass}", e.Message } });
        //    }
        //    return false;
        //}

        //public async Task<bool> FeedbackAsync(CommentModel[] comments, int lesson, long classroomId)
        //{
        //    try
        //    {
        //        var result = await Api.SendFeedback(new SendFeedbackRequestDto
        //        {
        //            Lesson = lesson,
        //            ClassroomId = classroomId,
        //            ListFeedback = comments.Where(d => !string.IsNullOrEmpty(d.Comment)).Select(d => new FeedbackRequestDto
        //            {
        //                CourseStudentId = d.User.Id,
        //                Content = d.Comment

        //            }).ToArray()
        //        });

        //        return result.ToResult();
        //    }
        //    catch (Exception e)
        //    {
        //        logService.Log(e, new Dictionary<string, string>() { { $"Feedback student error . classroom id {classroomId}, lesson {lesson}", e.Message } });

        //    }
        //    return false;
        //}

        public async Task<ClassModel[]> GetAllClassesAsync()
        {
            try
            {
                var result = await api.GetClassrooms();
                if (result?.Data?.Length > 0)
                {
                  //  return result.Data.Where(c => c.NearestDate != null).Select(d => d.ToModel()).ToArray();
                }

            }
            catch (Exception e)
            {
            //    logService.Log(e, new Dictionary<string, string>() { { "Get all class error ", e.Message } });

            }
            return new ClassModel[0];
        }

        //public async Task<AttendanceModel[]> GetAttendancesAsync(int lesson, long classroomId)
        //{
        //    try
        //    {
        //        var result = await Api.GetAttendance(classroomId, lesson);
        //        if (result?.Data?.Length > 0)
        //        {
        //            return result.Data.Select(d => d.ToAttendanceModel()).ToArray();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        logService.Log(e, new Dictionary<string, string>() { { $"Get attendance error . classroom id {classroomId}, lesson {lesson}", e.Message } });
        //    }
        //    return new AttendanceModel[0];
        //}


        //public async Task<CommentModel[]> GetFeedbacksAsync(int lesson, long classroomId)
        //{
        //    try
        //    {
        //        var result = await Api.GetFeedbacks(classroomId, lesson);
        //        if (result?.Data?.Length > 0)
        //        {
        //            return result.Data.Select(d => d.ToFeedbackModel()).ToArray();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        logService.Log(e, new Dictionary<string, string>() { { $"Get all feedback error . classroom id {classroomId}, lesson {lesson}", e.Message } });

        //    }
        //    return new CommentModel[0];
        //}

        //public async Task<HomeworkResultModel[]> GetHomeworksAsync(int lesson, long classroomId)
        //{
        //    try
        //    {
        //        var result = await Api.GetHomework(classroomId, lesson, "homework");
        //        if (result?.Data?.Length > 0)
        //        {
        //            return result.Data?.Select(d => d.ToHomeworkModel()).ToArray();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        logService.Log(e, new Dictionary<string, string>() { { $"Get homework student error. classroom id {classroomId}, lesson {lesson} ", e.Message } });
        //    }
        //    return new HomeworkResultModel[0];
        //}

        //public async Task<HomeworkResultModel[]> GetMarksAsync(int lesson, long classroomId)
        //{
        //    try
        //    {
        //        var result = await Api.GetMark(classroomId, lesson, "homework", 0);
        //        if (result?.Data?.Length > 0)
        //        {
        //            return result.Data?.Where(d => d.Test != null).Select(d => d.ToHomeworkModel()).ToArray();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        logService.Log(e, new Dictionary<string, string>() { { $"Get list homework for mark error. classroom id {classroomId}, lesson {lesson} ", e.Message } });
        //    }
        //    return new HomeworkResultModel[0];
        //}

        //public async Task<LessonModel> GetLessonAsync(int lesson, long classroomId)
        //{
        //    try
        //    {
        //        var result = await Api.Learn(classroomId, lesson);
        //        if (result?.Data != null)
        //        {
        //            var d = result.Data;
        //            return new LessonModel
        //            {
        //                Lesson = d.Name,
        //                Listening = d.Listening,
        //                Material = d.Material,
        //                Reading = d.Reading,
        //                Speaking = d.Speaking,
        //                Vocabulary = d.Vocabulary,
        //                Writing = d.Writing,
        //                Grammar = d.Grammar
        //            };
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        logService.Log(e, new Dictionary<string, string>() { { $"Get lesson error . classroom id {classroomId}, lesson {lesson}", e.Message } });
        //    }
        //    return null;
        //}

        //public async Task<ScheduleModel> GetRoutesAsync(long classroomId)
        //{
        //    try
        //    {
        //        var result = await Api.GetSchedule(classroomId);
        //        if (result?.Data?.ListDate?.Length > 0)
        //        {
        //            var routes = result.Data.ListDate.Where(d => !d.OffClass.HasValue || d.OffClass.Value == false).Select(d => d.ToModel(result.Data.Room, result.Data.Id)).OrderBy(d => d.Date).ToArray();
        //            var lessons = routes.Where(d => d.RouteType == RouteType.Lesson).ToArray();
        //            for (int i = 0; i < lessons.Length - 1; i++)
        //            {
        //                var first = lessons[i];
        //                var next = lessons[i + 1];
        //                first.Next = next.Date;
        //            }


        //            return new ScheduleModel()
        //            {
        //                ZoomId = result?.Data.ZoomId,
        //                ZoomPassword = result?.Data.ZoomPassword,
        //                Mode = result?.Data?.FormStudy?.ToLower() == "online" ? OnlineMode.Online : OnlineMode.Offline,
        //                Routes = routes
        //            };
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        logService.Log(e, new Dictionary<string, string>() { { $"Get routes error . classroom id {classroomId}", e.Message } });

        //    }
        //    return new ScheduleModel
        //    {
        //        Routes = new RouteModel[0]
        //    };
        //}

        //public async Task<UserModel[]> GetStudentsAsync(long classroomId)
        //{
        //    try
        //    {
        //        var result = await Api.GetStudents(classroomId);
        //        if (result?.Data?.Length > 0)
        //        {
        //            return result.Data.Select(d => d.ToModel()).ToArray();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        logService.Log(e, new Dictionary<string, string>() { { $"Get all student error . classroom id :{classroomId}", e.Message } });
        //    }
        //    return new UserModel[0];
        //}

        //public async Task<bool> OffClassAsync(int lesson, long classroomId)
        //{
        //    try
        //    {
        //        var result = await Api.OffClass(
        //            new OffClassRequestDto
        //            {
        //                Lesson = lesson,
        //                ClassroomId = classroomId
        //            });

        //        return result.ToResult();
        //    }
        //    catch (Exception e)
        //    {
        //        logService.Log(e, new Dictionary<string, string>() { { $"Off class error . class id : {classroomId}, lesson {lesson}", e.Message } });
        //    }
        //    return false;
        //}

        //public async Task<UserModel[]> GetAllTutorAsync(long classId)
        //{
        //    try
        //    {
        //        var result = await Api.GetAllTutor(classId);
        //        if (result?.Data?.Length > 0)
        //        {
        //            return result.Data.Select(d => d.ToModel()).ToArray();
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        logService.Log(e, new Dictionary<string, string>() { { $"Get all Tutoring class error . class id :{classId}", e.Message } });
        //    }
        //    return new UserModel[0];
        //}

        //public async Task<ScheduleModel> GetRoutesAsync(long classroomId, long tutorId)
        //{
        //    try
        //    {
        //        var result = await Api.GetSchedule(classroomId);
        //        if (result?.Data?.ListDate?.Length > 0)
        //        {
        //            var routes = result.Data.ListDate.Where(d => (!d.OffClass.HasValue || d.OffClass.Value == false)).Select(d => d.ToModel(result.Data.Room, result.Data.Id)).SkipWhile(d => d.RouteType == RouteType.SupportClass && d.TutorId == tutorId).OrderBy(d => d.Date).ToArray();
        //            var lessons = routes.Where(d => d.RouteType == RouteType.Lesson).ToArray();
        //            for (int i = 0; i < lessons.Length - 1; i++)
        //            {
        //                var first = lessons[i];
        //                var next = lessons[i + 1];
        //                first.Next = next.Date;
        //            }


        //            return new ScheduleModel()
        //            {
        //                ZoomId = result?.Data.ZoomId,
        //                ZoomPassword = result?.Data.ZoomPassword,
        //                Mode = result?.Data?.FormStudy?.ToLower() == "online" ? OnlineMode.Online : OnlineMode.Offline,
        //                Routes = routes
        //            };
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        logService.Log(e, new Dictionary<string, string>() { { $"Get routes class tutoring error. classroom id {classroomId}, tutor id {tutorId} ", e.Message } });
        //    }
        //    return new ScheduleModel
        //    {
        //        Routes = new RouteModel[0]
        //    };
        //}
    }
}
