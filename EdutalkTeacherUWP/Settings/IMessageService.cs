using EdutalkTeacherUWP.Api.Authorization;
using EdutalkTeacherUWP.Api.Base;
using EdutalkTeacherUWP.Api.Extensions;
using EdutalkTeacherUWP.Api.Utils;
using EdutalkTeacherUWP.Common.Extensions;
using EdutalkTeacherUWP.Message.Models;
using EdutalkTeacherUWP.Settings.Service;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Settings
{
    public interface IMessageService
    {
        Task<ConversationModel[]> GetAllConversationsAsync();
        Task<MessageModel[]> GetAllMessagesAsync(long conversationId);

        Task<bool> SendMessageAsync(long conversationId, string message);
    }

    public class MessageService : IMessageService
    {
        readonly IApplicationSettings applicationSettings;
        readonly IAuthHeaderManager authHeader;
        readonly IApiBase apiBase;
        IEdutalkApi Api;
        public MessageService()
        {
            apiBase = new ApiBase();
            authHeader = new AuthHeaderManager();
            var token = authHeader.GetBearerToken().Result;
            applicationSettings = new ApplicationSettings();
            Api = RestService.For<IEdutalkApi>(new HttpClient(new AuthenticatedHttpClientHandler(() => authHeader.GetBearerToken())) { BaseAddress = new Uri(apiBase.ServerApi) }, RefitSetting.SnakeCaseNaming);

        }


        public async Task<ConversationModel[]> GetAllConversationsAsync()
        {
            try
            {
                var result = await Api.GetAllConversations();
                if (result?.Data?.Length > 0)
                {
                    return result.Data.Where(d => !string.IsNullOrEmpty(d.LastMessage)).Select(d => d.ToModel()).ToArray();
                }
            }
            catch (Exception e)
            {
            }
            return new ConversationModel[0];
        }


        public async Task<MessageModel[]> GetAllMessagesAsync(long conversationId)
        {
            try
            {
                var result = await Api.GetConversationMessages(conversationId, 1, 1000);
                if (result?.Data?.Length > 0)
                {
                    return result.Data.Select(d => new MessageModel
                    {
                        Id = d.Id,
                        Message = d.Message,
                        Status = MessageStatus.Seen,
                        Time = d.Time,
                        IsMine = d.IsStudent == 0,
                        Type = d.Type,
                        Lesson = d.Lesson
                    }).ToArray();
                }
            }
            catch (Exception e)
            {
            }
            return new MessageModel[0];
        }


        public async Task<bool> SendMessageAsync(long conversationId, string message)
        {
            try
            {
                var result = await Api.SendMessage(conversationId, message);
                return result != null;
            }
            catch (Exception e)
            {
            }
            return false;
        }


    }
}
