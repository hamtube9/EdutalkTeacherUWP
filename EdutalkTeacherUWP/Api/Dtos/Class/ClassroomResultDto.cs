using EdutalkTeacherUWP.Api.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.Class
{
    public class ClassroomResultDto
    {
        public long Id { get; set; }
        public string FormStudy { get; set; }
        public string StartDate { get; set; }
        public string Name { get; set; }
        public string RoomName { get; set; }
        public CourseResultDto Course { get; set; }
        public NearestDateResultDto NearestDate { get; set; }
    }

    public class NearestDateResultDto
    {
        //public long Id { get; set; }
        //public string Name { get; set; }
        //public long ClassroomId { get; set; }
        //public long RoomId { get; set; }
        public string Date { get; set; }
        [JsonIgnore]
        public DateTime DateTime => Date.ToNormalDateTime("yyyy-MM-dd");
        //public string Note { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        [JsonIgnore]
        public TimeSpan Start => StartTime.ToNormalTime();
        [JsonIgnore]
        public TimeSpan End => EndTime.ToNormalTime();
    }

    public class CourseResultDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FeaturedImage { get; set; }
    }
}
