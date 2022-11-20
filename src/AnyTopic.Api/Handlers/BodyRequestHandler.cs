using AnyTopic.Api.Logging;
using AnyTopic.Api.Models;
using EnsureThat;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AnyTopic.Api.Handlers
{
    public abstract class BodyRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : class, IBodyRequest<TResponse>
        where TResponse : IApiResponse
    {
        private static readonly JsonSerializerOptions ResponseSerializerOptions;
        private static readonly ILogger<BodyRequestHandler<TRequest, TResponse>> Logger = AnyTopicLoggerFactory.CreateLogger<BodyRequestHandler<TRequest, TResponse>>();

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        protected ValueTask<TValue?> DeserializeAsync<TValue>(Stream stream, JsonSerializerOptions jsonOptions)
            where TValue : class
        {
            EnsureArg.IsNotNull(stream, nameof(stream));

            try
            {
                if (stream.CanSeek && stream.Position != 0L)
                {
                    stream.Seek(0L, SeekOrigin.Begin);
                }

                return JsonSerializer.DeserializeAsync<TValue>(stream, jsonOptions);
            }
            catch (Exception ex)
            {
                var error = ex!.InnerException?.Message ?? ex.Message;

                Logger.LogError(ex, error);

                return new (Task.FromResult((TValue?)null));
            }
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

        protected IActionResult GetApiResponse<TValue>(int statusCode, TValue? value = null)
            where TValue : class
        {
            IActionResult response = statusCode switch
            {
                StatusCodes.Status200OK => new JsonResult(value, ResponseSerializerOptions) { StatusCode = StatusCodes.Status200OK },

                _ => new StatusCodeResult(statusCode)
            };

            return response;
        }

        static BodyRequestHandler()
        {
            if (ResponseSerializerOptions == null)
            {
                ResponseSerializerOptions = new JsonSerializerOptions()
                {
                    AllowTrailingCommas = true,
                    DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                    IgnoreReadOnlyFields = true,
                    IgnoreReadOnlyProperties = true,
                    IncludeFields = false,
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    WriteIndented = true
                };
            }
        }
    }
}
