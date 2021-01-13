using EdutalkTeacherUWP.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Message.Models
{
    public class MessageModel : ModelBase
    {
        public long Id { set; get; }
        public bool IsMine { set; get; }
        public DateTime Time { set; get; }
        public string Message { set; get; }
        public int Lesson { set; get; }
        public string Type { set; get; }
        public MessageStatus Status { set; get; }
    }

    public enum MessageStatus
    {
        Sending = 0, Sent = 1, Error = 2, Seen = 3
    }
}
