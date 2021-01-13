using EdutalkTeacherUWP.Api.Dtos;
using EdutalkTeacherUWP.Api.Dtos.Authorizations;
using EdutalkTeacherUWP.Api.Dtos.ClassDtos;
using EdutalkTeacherUWP.Api.Dtos.Exam;
using EdutalkTeacherUWP.Api.Dtos.Messenger;
using EdutalkTeacherUWP.Api.Dtos.Route;
using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Exam.Models;
using EdutalkTeacherUWP.Home.Models;
using EdutalkTeacherUWP.Message.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Common.Extensions
{
    public static class ModelExtensions
    {
        //public static UserModel ToModel(this AccountUserResultDto dto)
        //{
        //    if (dto == null)
        //    {
        //        return null;
        //    }

        //    return new UserModel
        //    {
        //        Id = dto.Id,
        //        FirstName = dto.FirstName,
        //        LastName = dto.LastName,
        //        Email = dto.Email,
        //        Image = dto.Avatar?.Path
        //    };
        //}

        public static ResultModel ToModel(this ExamResultResultDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new ResultModel
            {
                Score = dto.Score,
                Process = dto.Process,
                Test = ToModel(dto.Test),
                TotalQuestion = dto.Test?.GroupQuestions?.Length ?? 0,
                TotalScore = dto.Test?.GroupQuestions?.Where(d => d.Score.HasValue)?.Sum(d => d.Score.Value) ?? 0
            };
        }
        public static ExamModel ToModel(this ExamResultDto d)
        {
            if (d == null)
            {
                return null;
            }
            return new ExamModel
            {
                Id = d.Id,
                TypeName = d.TypeName,
                Time = d.Time,
                Questions = d.GroupQuestions.Select(c => c.ToModel(d.GroupQuestions.ToList().IndexOf(c) + 1)).ToArray()
            };
        }
        public static GroupQuestionModel ToModel(this GroupQuestionResultDto d, int index = 0)
        {
            if (d == null)
            {
                return null;
            }
            return new GroupQuestionModel
            {
                Id = d.Id,
                Media = d.Audio,
                Category = d.ToCategory(),
                Image = d.Image,
                Script = d.Script,
                Questions = d.Questions.Select(c => c.ToModel(d.Questions.ToList().IndexOf(c) + 1)).ToList(),
                Number = index
            };
        }

        public static QuestionCategoryModel ToCategory(this GroupQuestionResultDto d)
        {

            return new QuestionCategoryModel
            {
                Title = d.Title,
                Description = d.Description,
                Category = d.Type.ToCategoryModel()
            };
        }

        public static QuestionModel ToModel(this QuestionResultDto d, int index = 0)
        {
            if (d == null)
            {
                return null;
            }

            return new QuestionModel
            {
                Id = d.Id,
                Image = d.Image,
                Audio = d.Audio,
                Type = d.Type,
                Question = d.Title,
                Answers = d.Answers.Select(c => c.ToModel()).ToList(),
                Index = index,
                IsTrue = d.IsTrue,
                StudentAnswer = d.StudentAnswer,
                CorrectAnswer = d.CorrectAnswer,
                FileImages = d.StudentAnswerImage.ToArrModel(),
                FileRecord = d.StudentAnswerRecord.ToModel(),
                Score = d.Score
            };
        }

        public static AnswerModel ToModel(this AnswerResultDto d)
        {
            if (d == null)
            {
                return null;
            }

            return new AnswerModel
            {
                Answer = d.Content,
                Position = d.Position,
                Image = d.Image,
                Audio = d.Audio
            };
        }
        public static string[] ToArrModel(this FileAnswerDto[] d)
        {
            if (d == null)
            {
                return null;
            }
            var arr = d.Select(f => f.PathString).ToArray();
            return arr;
        }

        public static string ToModel(this FileAnswerDto[] d)
        {
            if (d == null)
            {
                return null;
            }
            return d.FirstOrDefault()?.PathString;
        }

        public static QuestionCategory ToCategoryModel(this string d)
        {
            switch (d.ToLower())
            {
                case "fill_text_script":
                    return QuestionCategory.FillTextScript;
                case "fill_text_image":
                    return QuestionCategory.FillTextImage;
                case "arrange_sentences":
                    return QuestionCategory.ArrangeSentences;
                case "match_text_image":
                    return QuestionCategory.MatchTextImage;
                case "single_choice":
                    return QuestionCategory.SingleChoice;
                case "match_image_audio":
                    return QuestionCategory.MatchImageToAudio;
                case "match_text_audio":
                    return QuestionCategory.MatchTextToAudio;
                case "fill_text_audio":
                    return QuestionCategory.FillTextToAudio;
                case "record":
                case "record_audio":
                    return QuestionCategory.Record;
                case "typingcaptureimage":
                case "write_paragraph":
                    return QuestionCategory.TypingCaptureImage;
                default:
                    return QuestionCategory.Record;
            }
        }


        public static UserModel ToModel(this UserResultDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new UserModel
            {
                Id = dto.Id,
                Email = dto.Email,
                Image = dto.Profile?.Avatar?.Path,
                AccountType = dto.Profile?.AccountType == "tro_giang" ? AccountType.Tutor : AccountType.Teacher,
                FullName = dto.Fullname,
                Phone = dto.Profile?.Phone,
                Address = dto.Profile?.Address,
                Code = dto.Profile?.Code,
                Gender = dto.Profile?.Gender == "male" ? Gender.Male : Gender.Female,
                ReferralCode = dto.Profile?.IntroCode,
                VerifiedPhone = dto.Profile.VerifiedPhone == 1
            };
        }

        public static ConversationModel ToModel(this ConversationResultDto d)
        {
            if (d == null)
                return null;
            return new ConversationModel
            {
                LastMessage = new MessageModel()
                {
                    Message = d.LastMessage,
                    Time = d.UpdatedAt.ToNormalDateTime("yyyy-MM-dd HH:mm:ss"),
                },
                User = new UserModel()
                {
                    FullName = d.NameStudent,
                    Image = d.Avatar
                },
                Unread = d.UnRead == 1,
                Id = d.Id,
                BlockBy = d.BlockBy.HasValue ? d.BlockBy.Value : 0
            };
        }

        public static UserModel ToModel(this StudentResultDto d)
        {
            if (d == null)
            {
                return null;
            }
            return new UserModel
            {
                Id = d.Id,
                UserId = d.UserId,
                FullName = d.Name,
                Name = d.Name,
                Phone = d.Phone,
                Image = d.Avatar
            };
        }



        public static AttendanceModel ToAttendanceModel(this AttendanceResultDto d)
        {
            if (d == null)
            {
                return null;
            }
            return new AttendanceModel
            {
                User = d.ToModel(),
                Status = d.Value.ToModel()
            };
        }

        public static AttendanceStatus ToModel(this string d)
        {
            if (string.IsNullOrWhiteSpace(d))
            {
                return AttendanceStatus.A;
            }
            switch (d.ToLower())
            {
                case "a":
                    return AttendanceStatus.A;
                case "p":
                    return AttendanceStatus.P;
                default:
                    return AttendanceStatus.A;
            }
        }

        //public static CommentModel ToFeedbackModel(this FeedbackResultDto d)
        //{
        //    if (d == null)
        //    {
        //        return null;
        //    }
        //    return new CommentModel
        //    {
        //        User = d.ToModel(),
        //        Comment = d.Content
        //    };
        //}

        //public static CommentModel ToFeedbackModel(this TutoringResultDto d)
        //{
        //    if (d == null)
        //    {
        //        return null;
        //    }
        //    return new CommentModel
        //    {
        //        User = d.ToModel(),
        //        Comment = d.Feedback
        //    };
        //}

        public static AttendanceModel ToAttendanceModel(this TutoringResultDto d)
        {
            if (d == null)
            {
                return null;
            }
            return new AttendanceModel
            {
                User = d.ToModel(),
                Status = d.Attendance.ToModel()
            };
        }

        public static HomeworkResultModel ToHomeworkModel(this HomeworkResultDto d)
        {
            if (d == null)
            {
                return null;
            }
            return new HomeworkResultModel
            {
                User = d.ToModel(),
                Correct = d.Test?.Score ?? 0,
                Total = d.Test?.Total ?? 0
            };
        }


        public static RouteModel ToModel(this RouteResultDto d, string room, long classId,int spaceDay)
        {
            if (d == null)
            {
                return null;
            }
            var duration = d.EndTime - d.StartTime;
            return new RouteModel
            {
                Date = d.DateTime.Add(d.StartTime ?? TimeSpan.FromHours(0)),
                DatetimeStudy = $"{d.StartTime.Value.Hours}h{d.StartTime.Value.Minutes}-{d.EndTime.Value.Hours}h{d.EndTime.Value.Minutes}",
                DateMonthStudy = $"{d.DateTime.Day}-{d.DateTime.Month}",
                IsPass = d.DateTime < DateTime.Now ? true : false,
                IsPresent= DateTime.Now >= d.DateTime.Add(d.StartTime ?? TimeSpan.FromHours(0)) && DateTime.Now <= d.DateTime.AddDays(spaceDay) ? true : false,
                IsFuture = DateTime.Now < d.DateTime ? true : false,
                Durration = duration.HasValue ? duration.Value.TotalMinutes : 90,
                Name = d.Name ?? d.Lesson + "",
                Lesson = d.Lesson ?? 0,
                Room = new RoomModel { Id = d.RoomId ?? 0, Name = d.FormStudy == "online" ? "Online" : d.RoomName ?? room },
                ZoomId = d.ZoomId,
                ZoomPassword = d.ZoomPassword,
                Mode = d.FormStudy?.ToLower() == "online" ? OnlineMode.Online : OnlineMode.Offline,
                RouteType = d.GetRouteType(),
                Attendance = d.Action.ToAttendance(),
                Feedback = d.Action.ToFeedback(),
                Homework = d.Action.ToHomework(),
                Exam = d.Action.ToExam(),
                Mark = d.Action.ToMark(),
                Note = d.Note,
                Id = d.Id ?? 0,
                Next = d.DateTime.Add(d.EndTime ?? TimeSpan.FromHours(24)),
                IsTeacher = d.IsTeacher > 0,
                TutorId = d.TrogiangId,
                AttendanceTutor = d.Action?.Attendance?.TrogiangId
            };
        }

        public static RouteItemModel ToAttendance(this ActionResultDto d)
        {
            if (d == null || d.Attendance == null)
            {
                return null;
            }
            return new RouteItemModel
            {
                IsSuccess = d.Attendance.Count == d.Attendance.Total,
                Result = $"{d.Attendance.Count}/{d.Attendance.Total}",
                Progress = d.Attendance.Total == 0 ? 0 : d.Attendance.Count / d.Attendance.Total
            };
        }

        public static RouteItemModel ToFeedback(this ActionResultDto d)
        {
            if (d == null)
            {
                return null;
            }
            return new RouteItemModel
            {
                IsSuccess = d.Feedback
            };
        }

        public static RouteItemModel ToHomework(this ActionResultDto d)
        {
            if (d == null || d.Homework == null)
            {
                return null;
            }
            return new RouteItemModel
            {
                IsSuccess = d.Homework.Count == d.Homework.Total,
                Result = $"{d.Homework.Count}/{d.Homework.Total}",
                Progress = d.Homework.Total == 0 ? 0 : d.Homework.Count / d.Homework.Total
            };
        }

        public static RouteItemModel ToMark(this ActionResultDto d)
        {
            if (d == null || d.Homework == null || !d.Homework.NoMark.HasValue || d.Homework.NoMark == 0)
            {
                return null;
            }

            return new RouteItemModel
            {
                IsSuccess = d.Homework.NoMark == 0,
                Result = d.Homework.NoMark.HasValue ? $"{(d.Homework.Total - d.Homework.NoMark.Value)}/{d.Homework.Total}" : "",
                Progress = d.Homework.NoMark == 0 ? 0 : 1
            };
        }

        public static RouteItemModel ToExam(this ActionResultDto d)
        {
            if (d == null || d.Test == null)
            {
                return null;
            }
            return new RouteItemModel
            {
                IsSuccess = d.Test.Count == d.Test.Total,
                Result = $"{d.Test.Count}/{d.Test.Total}",
                Progress = d.Test.Total == 0 ? 0 : d.Test.Count / d.Test.Total
            };
        }

        public static RouteType GetRouteType(this RouteResultDto d)
        {
            if (d == null)
            {
                return RouteType.Lesson;
            }

            if (d.Test.HasValue)
            {
                return d.Test.Value == 0 ? RouteType.Lesson : RouteType.Exam;
            }

            if (d.IsTutoring.HasValue)
            {
                return d.IsTutoring.Value ? RouteType.SupportClass : RouteType.Lesson;
            }
            return RouteType.Lesson;
        }

        //public static RoomModel ToModel(this RoomResultDto d)
        //{
        //    if (d == null)
        //    {
        //        return null;
        //    }
        //    return new RoomModel
        //    {
        //        Id = d.Id,
        //        Name = d.Name
        //    };
        //}

        public static bool ToResult(this ErrorResultDto d)
        {
            if (d == null)
            {
                return false;
            }

            return d.Errors.HasValue && d.Errors.Value == false;
        }

        public static ClassModel ToModel(this ClassroomResultDto d)
        {
            if (d == null || d.NearestDate == null)
            {
                return null;
            }
            return new ClassModel
            {
                Id = d.Id,
                Mode = d.FormStudy == "online" ? OnlineMode.Online : OnlineMode.Offline,
                StartDate = d.StartDate.ToNormalDateTime("yyyy-MM-dd"),
                Name = d.Name,
                CourseName = d.Course?.Name,
                Image = d.Course?.FeaturedImage,
                Start = d.NearestDate.ToStartTime(),
                End = d.NearestDate.ToEndTime(),
                Room = d.RoomName
            };
        }

        public static DateTime ToStartTime(this NearestDateResultDto d)
        {
            if (d == null)
            {
                return DateTime.Now;
            }
            return d.DateTime.Add(-d.DateTime.TimeOfDay).Add(d.Start);
        }
        public static DateTime ToEndTime(this NearestDateResultDto d)
        {
            if (d == null)
            {
                return DateTime.Now;
            }
            return d.DateTime.Add(-d.DateTime.TimeOfDay).Add(d.End);
        }


        //public static ReportModel ToModel(this ReportClassDto dto)
        //{

        //    if (dto == null)
        //    {
        //        return null;
        //    }
        //    return new ReportModel()
        //    {
        //        Attendance = dto.Attendance.ToModel(),
        //        Feedback = dto.Feedback.ToModel(),
        //        Homework = dto.Homework.ToModel(),
        //        Test = dto.Test.ToModel()
        //    };
        //}

        //public static TestReportModel ToModel(this TestReportDto dto)
        //{
        //    if (dto == null)
        //    {
        //        return null;
        //    }

        //    return null;
        //}

        //public static AttendanceReportModel ToModel(this AttendanceReportDto dto)
        //{
        //    if (dto == null)
        //    {
        //        return null;
        //    }
        //    return new AttendanceReportModel()
        //    {
        //        Attendance = dto.CoMat,
        //        Off = dto.CoPhep,
        //        Total = dto.Total
        //    };
        //}

        //public static FeedbackReportModel[] ToModel(this FeedbackReportDto[] dto)
        //{
        //    if (dto == null)
        //    {
        //        return new FeedbackReportModel[0];
        //    }
        //    return dto.Select(d => d.ToModel()).ToArray();
        //}

        //public static FeedbackReportModel ToModel(this FeedbackReportDto dto)
        //{
        //    if (dto == null)
        //    {
        //        return null;
        //    }
        //    return new FeedbackReportModel()
        //    {
        //        Total = dto.Total,
        //        CountMark = dto.CountMark,
        //        Mark = dto.Mark
        //    };
        //}


        //public static HomeWorkReportModel[] ToModel(this HomeWorkReportDto[] dto)
        //{
        //    if (dto == null)
        //    {
        //        return new HomeWorkReportModel[0];
        //    }
        //    return dto.Select(d => d.ToModel()).ToArray();
        //}

        //public static HomeWorkReportModel ToModel(this HomeWorkReportDto dto)
        //{
        //    if (dto == null)
        //    {
        //        return null;
        //    }
        //    return new HomeWorkReportModel()
        //    {
        //        Count = dto.Count,
        //        Description = dto.Description,
        //        Level = dto.Level,
        //        Total = dto.Total
        //    };
        //}

    }
}
