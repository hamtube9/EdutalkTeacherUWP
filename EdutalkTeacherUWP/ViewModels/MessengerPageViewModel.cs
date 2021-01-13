using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Message.Models;
using EdutalkTeacherUWP.Settings;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EdutalkTeacherUWP.ViewModels
{
  public  class MessengerPageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        IMessageService messengerServices;

        public bool IsVisible { set; get; }
        public List<ConversationModel> Conversations { set; get; }
        public ObservableCollection<MessageModel> Messages { set; get; } = new ObservableCollection<MessageModel>();
        public ConversationModel Chat { set; get; }
        public UserModel User { set; get; }

        public MessengerPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            messengerServices = new MessageService();
            SetData();
        }

        private async void SetData()
        { await LoadConversation(); }

        async Task LoadConversation()
        {
            var result = await messengerServices.GetAllConversationsAsync();
            Conversations = new List<ConversationModel>(result);
        }

        ICommand _SelectedConversationCommand;
        public ICommand SelectedConversationCommand => _SelectedConversationCommand = _SelectedConversationCommand ?? new Prism.Commands.DelegateCommand<ConversationModel>(SelectedConversation);


        async void SelectedConversation (ConversationModel obj)
        {
            if(obj != null)
            {
                IsVisible = true;
                Chat = obj;
                User = obj?.User;
                var mess = await messengerServices.GetAllMessagesAsync(Chat.Id);
                if(mess != null)
                {
                    Messages = new ObservableCollection<MessageModel>(mess);
                }
            }
        }

    }
}
