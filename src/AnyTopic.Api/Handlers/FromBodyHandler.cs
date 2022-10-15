using AnyTopic.Api.Models;
using EnsureThat;
using MediatR;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AnyTopic.Api.Handlers
{
    public abstract class FromBodyHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : class, IFromBodyRequest<TResponse>
        where TResponse : IApiResponse
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        protected ValueTask<TValue?> DeserializeAsync<TValue>(Stream stream, JsonSerializerOptions jsonOptions)
            where TValue : class
        {
            EnsureArg.IsNotNull(stream, nameof(stream));

            if (stream.CanSeek && stream.Position != 0L)
            {
                stream.Seek(0L, SeekOrigin.Begin);
            }

            return JsonSerializer.DeserializeAsync<TValue>(stream, jsonOptions);
        }

        protected ValueTask<TValue?> DeserializeAsync<TValue>(Stream stream)
            where TValue : class
        {
            var jsonOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                IgnoreReadOnlyFields = true,
                IgnoreReadOnlyProperties = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString,
                MaxDepth = 5000
            };

            return DeserializeAsync<TValue>(stream, jsonOptions);
        }
    }
}
