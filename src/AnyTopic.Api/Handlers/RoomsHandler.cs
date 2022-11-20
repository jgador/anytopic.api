using AnyTopic.Api.Models;
using AnyTopic.Data.Contexts;
using AnyTopic.Data.Entities;
using EnsureThat;
using EntityToDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using static AnyTopic.Api.Handlers.RoomsHandler;

namespace AnyTopic.Api.Handlers
{
    public class RoomsHandler : BodyRequestHandler<NewRoomRequest, Response>
    {
        private readonly IDbContextFactory<AnyTopicContext> _dbContextFactory;

        public RoomsHandler([NotNull] IDbContextFactory<AnyTopicContext> dbContextFactory)
        {
            EnsureArg.IsNotNull(dbContextFactory, nameof(dbContextFactory));

            _dbContextFactory = dbContextFactory;
        }

        public override async Task<Response> Handle(NewRoomRequest request, CancellationToken cancellationToken)
        {
            var requestDto = await DeserializeAsync<NewRoomDto>(request.Stream).ConfigureAwait(false);

            if (requestDto == null)
            {
                var actionResult = GetApiResponse<Response>(StatusCodes.Status400BadRequest);

                return new() { ActionResult = actionResult };
            }

            await using (var context = _dbContextFactory.CreateDbContext())
            {
                var newRoom = new Room()
                {
                    Name = requestDto.Name
                };

                await context.Room.AddAsync(newRoom, cancellationToken).ConfigureAwait(false);

                await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                var dto = Mapper.Map<RoomDto, Room>(newRoom, MappingDepth.Primitives);

                return new()
                {
                    ActionResult = GetApiResponse(StatusCodes.Status200OK, dto)
                };
            }
        }

        public class NewRoomRequest : BodyRequest<Response>
        {
            public NewRoomRequest([NotNull] Stream stream, [NotNull] ClaimsPrincipal user)
                : base(stream, user)
            {
            }
        }

        public class Response : IApiResponse
        {
            public IActionResult? ActionResult { get; set; }
        }
    }
}
