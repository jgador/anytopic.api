using EnsureThat;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace AnyTopic.Api.Models
{
    public abstract class FromBodyRequest<TResponse> : IFromBodyRequest<TResponse>
        where TResponse : IApiResponse
    {
        protected FromBodyRequest([NotNull] Stream stream, [NotNull] ClaimsPrincipal user)
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
