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
    [Route("api/messages")]
    [ApiController]
    public class MessagesController : BaseController<MessagesController>
    {
        private readonly IHubContext<ChatHub, IChatHubClient> _hubContext;
        public MessagesController(IHubContext<ChatHub, IChatHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task GetAsync()
        {
            var email = GetEmailClaim();

            if (email != null)
            {
                await _hubContext.Clients.All.SendMessageAsync(email, "Hello World");
            }
        }
    }
}
