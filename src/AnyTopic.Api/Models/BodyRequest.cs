using EnsureThat;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace AnyTopic.Api.Models
{
    public abstract class BodyRequest<TResponse> : IBodyRequest<TResponse>
        where TResponse : IApiResponse
    {
        protected BodyRequest([NotNull] Stream stream, [NotNull] ClaimsPrincipal user)
        {
            EnsureArg.IsNotNull(stream, nameof(stream));
            EnsureArg.IsNotNull(user, nameof(user));

            Stream = stream;
            User = user;
        }

        public Stream Stream { get; }

        public ClaimsPrincipal User { get; }
    }
}
