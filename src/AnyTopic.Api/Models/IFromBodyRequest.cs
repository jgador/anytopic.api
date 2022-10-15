using MediatR;
using System.Security.Claims;

namespace AnyTopic.Api.Models
{
    public interface IFromBodyRequest
    {
        Stream Stream { get; }

        ClaimsPrincipal User { get; }
    }

    public interface IFromBodyRequest<out TResponse> : IFromBodyRequest, IRequest<TResponse>
        where TResponse : IApiResponse
    {
    }
}
