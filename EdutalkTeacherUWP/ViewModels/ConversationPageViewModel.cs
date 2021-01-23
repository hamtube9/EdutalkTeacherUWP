using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Message.Models;
using EdutalkTeacherUWP.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.ViewModels
{
    public class ConversationPageViewModel : ViewModelBase
    {
        public ObservableCollection<MessageModel> Messages { set; get; } = new ObservableCollection<MessageModel>();
        public bool IsVisible { set; get; }
        public string Message { set; get; }
        public long ConversationId { set; get; }
        IMessageService messageService;
        public ConversationPageViewModel()
        {
            messageService = new MessageService();
        }

        public void SetData(MessageModel[] data)
        {
            Messages = new ObservableCollection<MessageModel>(data);
            IsVisible = Messages.Count > 0 ;
        }

        public async Task<bool> SendMessageAsync()
        {
            if (string.IsNullOrEmpty(Message))
            {
                return false;
            }
            var result =await messageService.SendMessageAsync(ConversationId, Message);
            if (result)
            {
                Messages.Add(new MessageModel()
                {
                    Message = Message,
                    IsMine = true,
                });
                Message = string.Empty;
                return true;
            }
            else
            {
                Toast("Gửi không thành công");
                return false;
            }
        }
    }
}
