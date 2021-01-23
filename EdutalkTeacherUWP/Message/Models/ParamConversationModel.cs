using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Message.Models
{
    public class ParamConversationModel
    {
        public long ConversationId { set; get; }
        public MessageModel[] Messages { set; get; }
    }
}
