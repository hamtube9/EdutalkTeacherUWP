using EdutalkTeacherUWP.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Route.Models
{
    public enum AttendanceStatus
    {
        N, A, P
    }
    public enum ConfirmAttendanceStatus
    {
        Not, Confirmed
    }


    public class AttendanceModel  
    {
        public UserModel User { get; set; }
        public AttendanceStatus Status { get; set; }
    }
}
