using AnyTopic.Api.Hubs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        public MessagesController([NotNull] IMediator mediator, IHubContext<ChatHub, IChatHubClient> hubContext)
            : base(mediator)
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
