using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AnyTopic.Api.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        public ChatController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        // GET: api/<ChatController>
        [HttpGet]
        public async Task GetAsync()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "Jesse", "Hello World");
        }

        // GET api/<ChatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ChatController>
        [Route("send")]
        [HttpPost]
        public async Task SendAsync([FromBody] string message)
        {
            await Task.CompletedTask;
            // await _chatHub.SendMessageAsync("Jesse", message).ConfigureAwait(false);
        }

        // PUT api/<ChatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
