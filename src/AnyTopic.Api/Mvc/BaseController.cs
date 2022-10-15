using AnyTopic.Api.Logging;
using AnyTopic.Api.Security.Claims;
using EnsureThat;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace AnyTopic.Api.Mvc
{
    [Authorize]
    [ApiController]
    public abstract class BaseController<TController> : ControllerBase
        where TController : BaseController<TController>
    {
        private static readonly JsonSerializerOptions ResponseSerializerOptions;

        protected readonly IMediator Mediator;
        protected readonly ILogger<TController> Logger;
        protected readonly IClaimsPrincipalProvider ClaimsPrincipalProvider;

        public BaseController([NotNull] IMediator mediator)
        {
            EnsureArg.IsNotNull(mediator, nameof(mediator));

            Mediator = mediator;

            Logger = AnyTopicLoggerFactory.CreateLogger<TController>();
            ClaimsPrincipalProvider = ClaimsPrincipalProviderFactory.GetClaimsPrincipalProvider();
        }

        protected string? GetEmailClaim()
        {
            const string EmailClaimType = "emails";

            return ClaimsPrincipalProvider
                .GetPrincipal()
                .Claims
                .FirstOrDefault(claim => claim.Type == EmailClaimType)?.Value;
        }

        protected IActionResult? ApiResponse<T>(T value, int statusCode)
            where T : class
        {
            IActionResult result = statusCode switch
            {
                StatusCodes.Status200OK => new JsonResult(value, ResponseSerializerOptions) { StatusCode = StatusCodes.Status200OK },

                StatusCodes.Status204NoContent or
                StatusCodes.Status500InternalServerError or
                _ => new StatusCodeResult(statusCode),
            };

            Logger.LogInformation(result?.ToString());

            return result;
        }

        static BaseController()
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
