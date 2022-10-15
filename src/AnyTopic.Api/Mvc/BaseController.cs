using AnyTopic.Api.Logging;
using AnyTopic.Api.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace AnyTopic.Api.Mvc
{
    [Authorize]
    [ApiController]
    public abstract class BaseController<TController> : ControllerBase
        where TController : BaseController<TController>
    {
        private static readonly JsonSerializerOptions ResponseSerializerOptions;
        protected readonly ILogger<TController> Logger;
        protected readonly IClaimsPrincipalProvider ClaimsPrincipalProvider;

        public BaseController()
        {
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
