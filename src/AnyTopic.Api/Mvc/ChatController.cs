using AnyTopic.Api.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyTopic.Api.Mvc
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub, IChatHubClient> _hubContext;
        public ChatController(IHubContext<ChatHub, IChatHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task GetAsync()
        {
            await _hubContext.Clients.All.SendMessageAsync("Jesse", "Hello World");
        }
    }
}
