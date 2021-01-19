using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Message.Models;
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
        public ConversationPageViewModel()
        {

        }

        public void SetData(MessageModel[] data)
        {
            Messages = new ObservableCollection<MessageModel>(data);
            IsVisible = Messages.Count > 0 ;
        }
    }
}
