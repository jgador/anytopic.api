using Microsoft.AspNetCore.SignalR;

namespace AnyTopic.Api.Hubs
{
    public interface IChatHubClient
    {
        [HubMethodName("receiveMessage")]
        public Task SendMessageAsync(string user, string message);
    }
}
