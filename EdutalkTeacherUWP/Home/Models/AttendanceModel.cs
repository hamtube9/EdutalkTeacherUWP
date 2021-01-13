using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Home.Models
{
    public enum AttendanceStatus
    {
        A, P
    }
    public enum ConfirmAttendanceStatus
    {
        Not, Confirmed
    }


    public class AttendanceModel : ModelBase
    {
        public UserModel User { get; set; }
        public AttendanceStatus Status { get; set; }
        public bool IsAttendance
        {

            set
            {
                value = this.Status == AttendanceStatus.A ? false : true;
            }
            get
            {
                return this.Status == AttendanceStatus.A ? false : true; ;
            }
        }
        public string StatusAttendance
        {
            set
            {
                value = this.Status == AttendanceStatus.A ? "Absent" : "Passed";
            }
            get
            {
                return this.Status == AttendanceStatus.A ? "Absent" : "Passed";
            }
        }
    }
}
