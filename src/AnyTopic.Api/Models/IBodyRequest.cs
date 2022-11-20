using MediatR;
using System.Security.Claims;

namespace AnyTopic.Api.Models
{
    public interface IBodyRequest
    {
        Stream Stream { get; }

        ClaimsPrincipal User { get; }
    }

    public interface IBodyRequest<in TRequestDto, out TResponse> : IBodyRequest, IRequest<TResponse>
        where TRequestDto : class
        where TResponse : IApiResponse
    {
    }

    public interface IBodyRequest<out TResponse> : IBodyRequest, IRequest<TResponse>
        where TResponse : IApiResponse
    {
    }
}
