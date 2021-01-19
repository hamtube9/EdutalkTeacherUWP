using EdutalkTeacherUWP.Api.Dtos;
using EdutalkTeacherUWP.Api.Dtos.Authorizations;
using EdutalkTeacherUWP.Api.Dtos.ClassDtos;
using EdutalkTeacherUWP.Api.Dtos.Exam;
using EdutalkTeacherUWP.Api.Dtos.Messenger;
using EdutalkTeacherUWP.Api.Dtos.RoomDto;
using EdutalkTeacherUWP.Api.Dtos.Route;
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

        //attendance
        [Get("/api/v3/mobile/teacher/class/attendance/list?classroom_id={classroomId}&lesson={lesson}")]
        Task<DataDto<AttendanceResultDto[]>> GetAttendance(long classroomId, int lesson);


        [Get("/api/v3/mobile/teacher/class/tutoring?id={id}")]
        Task<DataDto<TutoringResultDto[]>> GetTutoring(long id);


        [Post("/api/v3/mobile/teacher/class/attendance/submit")]
        Task<ErrorResultDto> SubmitAttendance([Body] SubmitAttendanceRequestDto request);

        [Get("/api/v3/mobile/teacher/class/list-tro-giang?classroom_id={classroomId}")]
        Task<DataDto<UserResultDto[]>> GetAllTutor(long classroomId);

        [Post("/api/v3/mobile/teacher/class/tutoring/attendance")]
        Task<ErrorResultDto> SubmitAttendanceTutoring([Body] SubmitAttendanceTutoringRequestDto request);

        //ROUTE

        [Get("/api/v3/mobile/teacher/class/schedule?id={id}")]
        Task<DataDto<ScheduleResultDto>> GetSchedule(long id);


        [Get("/api/v3/mobile/teacher/chats/threads")]
        Task<DataDto<ConversationResultDto[]>> GetAllConversations();

        [Get("/api/v3/mobile/teacher/chats/threads/messages?thread_id={threadid}?page={page}&per_page={limit}")]
        Task<DataDto<MessageResultDto[]>> GetConversationMessages(long threadid, int page, int limit);

        [Post("/api/v3/mobile/teacher/chats/threads/messages/send?thread_id={conversationId}&message={message}")]
        Task<MessageResultDto> SendMessage(long conversationId, string message);


        //HOMEWORK
        [Get("/api/v3/mobile/teacher/class/list-student?id={classroomId}")]
        Task<DataDto<StudentResultDto[]>> GetStudents(long classroomId);
        [Get("/api/v3/mobile/teacher/class/exam/list?classroom_id={classroomId}&lesson={lesson}&type=homework")]
        Task<DataDto<HomeworkResultDto[]>> GetHomework(long classroomId, int lesson, string type);

        [Get("/api/v3/mobile/teacher/class/student/result?course_student_id={courseStudentId}&classroom_id={classroomId}&lesson={lesson}&type={type}&status_mark=1")]
        Task<ErrorResultDto<ExamResultResultDto>> GetResult(int courseStudentId, long classroomId, long lesson, string type);


        //ROOM

        [Get("/api/v3/mobile/teacher/class/list-room?id={classroomId}")]
        Task<DataDto<RoomResultDto[]>> GetRoom(long classroomId);

        [Get("/api/v3/mobile/teacher/class/list-room?id={classroomId}&date={date}&start_time={start}&end_time={end}")]
        Task<DataDto<RoomResultDto[]>> GetRoom(long classroomId, string date, string start, string end);

        //SUPPORT CLASS
        [Post("/api/v3/mobile/teacher/class/tutoring/create")]
        Task<ErrorResultDto> CreateTutoring([Body] CreateTutoringRequestDto request);

        [Post("/api/v3/mobile/teacher/class/tutoring/update")]
        Task<ErrorResultDto> UpdateTutoring([Body] UpdateTutoringRequestDto request);

        [Post("/api/v3/mobile/teacher/class/tutoring/delete")]
        Task<ErrorResultDto> DeleteTutoring([Body] DeleteingRequestDto request);
    }
}
