using EdutalkTeacherUWP.Api.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.Route
{
    public class ScheduleResultDto
    {
        public long Id { get; set; }
        public string FormStudy { get; set; }
        public string ZoomId { get; set; }
        public string ZoomPassword { get; set; }
        public string Name { get; set; }
        public string Room { get; set; }
        public RouteResultDto[] ListDate { get; set; }
    }

    public class RouteResultDto
    {
        public bool? OffClass { get; set; }
        public string Date { set; get; }
        [JsonIgnore]
        public DateTime DateTime => Date.ToNormalDateTime("yyyy-MM-dd");
        //public DayOfWeek? DateOfWeek { get; set; } 
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? Lesson { get; set; }
        public int? Test { get; set; }
        public long? Homework { get; set; }
        public long? IsFinish { get; set; }
        public ActionResultDto Action { get; set; }
        public long? Id { get; set; }
        public string Name { get; set; }
        public long? ClassroomId { get; set; }
        public long? RoomId { get; set; }
        public string Note { get; set; }
        public string ZoomId { set; get; }
        public string ZoomPassword { set; get; }
        public string FormStudy { get; set; }
        public bool? IsTutoring { get; set; }
        public string RoomName { get; set; }
        public int? IsTeacher { get; set; }
        public long? TrogiangId { get; set; }
    }

    public class ActionResultDto
    {
        public AttendanceReportResultDto Attendance { get; set; }
        public bool Feedback { get; set; }
        public AttendanceReportResultDto Homework { get; set; }
        public AttendanceReportResultDto Test { get; set; }
    }

    public class AttendanceReportResultDto
    {
        public double Count { get; set; }
        public double Total { get; set; }
        public double? NoMark { get; set; }
        public long? TrogiangId { get; set; }
    }
}
