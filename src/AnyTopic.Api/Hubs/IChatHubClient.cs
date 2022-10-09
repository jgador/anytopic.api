using AnyTopic.Api.Constants;
using Microsoft.AspNetCore.SignalR;

namespace AnyTopic.Api.Hubs
{
    public interface IChatHubClient
    {
        [HubMethodName(ChatHubContants.Client.User.ReceiveMessage)]
        public Task SendMessageAsync(string user, string message);
    }
}
