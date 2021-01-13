using EdutalkTeacherUWP.Api.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.Messenger
{
    public class MessageResultDto
    {
        public long Id { get; set; }
        public long read { get; set; }
        public long IsStudent { get; set; }
        public string Message { get; set; }
        public string CreatedAt { get; set; }
        public string Type { get; set; }
        public int Lesson { set; get; }
        public long? DeleteBy { get; set; }

        [JsonIgnore]
        public DateTime Time => CreatedAt.ToNormalDateTime("yyyy-MM-dd HH:mm:ss");

    }
}
