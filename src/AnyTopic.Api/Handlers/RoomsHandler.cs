using AnyTopic.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using static AnyTopic.Api.Handlers.RoomsHandler;

namespace AnyTopic.Api.Handlers
{
    public class RoomsHandler : FromBodyHandler<Request, Response>
    {
        public override async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var requestDto = await DeserializeAsync<NewRoomDto>(request.Stream).ConfigureAwait(false);

            return new () { JsonResult = new (requestDto) };
        }

        public class Request : FromBodyRequest<Response>
        {
            public Request([NotNull] Stream stream, [NotNull] ClaimsPrincipal user)
                : base(stream, user)
            {
            }
        }

        public class Response : IApiResponse
        {
            public JsonResult? JsonResult { get; set; }
        }
    }
}
