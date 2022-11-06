using AnyTopic.Api.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace AnyTopic.Api.Mvc
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomsController : BaseController<RoomsController>
    {
        public RoomsController([NotNull] IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult?> NewRoomAsync(CancellationToken cancellationToken)
        {
            using (var stream = Request.BodyReader.AsStream(true))
            {
                var request = new RoomsHandler.Request(stream, User);

                var response = await Mediator.Send(request, cancellationToken).ConfigureAwait(false);

                return response.ActionResult;
            }
        }
    }
}
