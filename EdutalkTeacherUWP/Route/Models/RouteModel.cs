using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Route.Models
{
    public enum RouteType
    {
        Lesson, Exam, SupportClass
    }
    public class RouteModel 
    {
        public long Id { get; set; }
        public int Lesson { get; set; }
        public string Name { get; set; }
        public string ZoomId { set; get; }
        public string ZoomPassword { set; get; }
        public OnlineMode Mode { get; set; }
        public DateTime Date { get; set; }
        public DateTime End => Date.AddMinutes(Durration);
        public DateTime Next { get; set; }
        //public string Room { get; set; } 
        public double Durration { get; set; } = 90;//Mins
        public string Note { get; set; }
        public RouteType RouteType { get; set; }
        public long? TutorId { get; set; }
        public bool IsTeacher { get; set; }

        public long? AttendanceTutor { get; set; }

        public bool VisibleHomework => RouteType == RouteType.Lesson;
        public bool VisibleCreateSupportClass => RouteType == RouteType.Lesson && (DateTime.Now >= End.AddMinutes(-15) && DateTime.Now < Next);
        public bool VisibleUpdateSupportClass => RouteType == RouteType.SupportClass && DateTime.Now < Date.AddMinutes(-5);
        public bool VisibleFeedback => RouteType != RouteType.Exam && !VisibleUpdateSupportClass;
        public bool VisibleAttendance => VisibleFeedback;
        public bool VisibleMark => RouteType == RouteType.Lesson && Mark != null;
        public bool VisibleUpdateSupportClassForTutor { set; get; }
        public bool VisibleFeedbackForTutor => RouteType != RouteType.Exam && !VisibleUpdateSupportClassForTutor;
        public bool VisibleAttendanceForTutor => VisibleFeedbackForTutor;
        public RouteItemModel Attendance { get; set; }
        public RouteItemModel Feedback { get; set; }
        public RouteItemModel Homework { get; set; }
        public RouteItemModel Exam { get; set; }
        public RouteItemModel Mark { get; set; }

        public RoomModel Room { get; set; }
    }

    public class SupportClassModel  
    {
        public long Id { get; set; }
        public string Note { get; set; }
    }

    public class RouteItemModel  
    {
        public string Result { get; set; }
        public double Progress { get; set; }
        public bool IsSuccess { get; set; }
    }

    public class ScheduleModel
    {
        public OnlineMode Mode { set; get; }
        public string ZoomId { set; get; }
        public string ZoomPassword { set; get; }
        public RouteModel[] Routes { set; get; }

    }
}
