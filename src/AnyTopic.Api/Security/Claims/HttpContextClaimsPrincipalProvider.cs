using EnsureThat;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace AnyTopic.Api.Security.Claims
{
    internal class HttpContextClaimsPrincipalProvider : IClaimsPrincipalProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextClaimsPrincipalProvider([NotNull] IHttpContextAccessor httpContextAccessor)
        {
            EnsureArg.IsNotNull(httpContextAccessor, nameof(httpContextAccessor));

            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal GetPrincipal()
        {
            EnsureArg.IsNotNull(_httpContextAccessor.HttpContext, nameof(_httpContextAccessor.HttpContext));

            return _httpContextAccessor.HttpContext!.User;
        }
    }
}
