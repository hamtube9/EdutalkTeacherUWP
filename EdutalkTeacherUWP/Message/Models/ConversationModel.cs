using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Message.Models
{
    public class ConversationModel : ModelBase
    {
        public long Id { get; set; }
        public UserModel User { get; set; }
        public MessageModel LastMessage { get; set; }
        public bool Unread { get; set; }
        public bool Available { get; set; }
        public long ClassId { get; set; }
        public long BlockBy { set; get; }
        public bool Blocked => BlockBy > 0;
    }
}
