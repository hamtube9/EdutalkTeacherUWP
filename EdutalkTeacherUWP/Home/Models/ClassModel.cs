using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Home.Models
{
    public class ClassModel : ModelBase
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public OnlineMode Mode { set; get; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Image { get; set; }
        public string CourseName { get; set; }
        public long Id { get; set; }
        public string Room { get; set; }
        public string Time => Start.ToStartStr() + "-" + End.ToEndStr();
    }

    public enum OnlineMode
    {
        Online = 0, Offline = 1
    }
}
