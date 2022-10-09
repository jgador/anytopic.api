using Microsoft.AspNetCore.SignalR;

namespace AnyTopic.Api.Hubs
{
    public class ChatHub : Hub<IChatHubClient>
    {
    }
}
