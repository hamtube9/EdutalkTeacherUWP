using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.Messenger
{
    public class ConversationResultDto
    {
        public long Id { get; set; }
        public string Avatar { get; set; }
        public string NameStudent { get; set; }
        public string LastMessage { get; set; }
        public long Status { set; get; }
        public long UnRead { set; get; }
        public string UpdatedAt { set; get; }
        public long? BlockBy { get; set; }

    }
}
