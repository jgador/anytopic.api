using System.Security.Claims;

namespace AnyTopic.Api.Security.Claims
{
    public interface IClaimsPrincipalProvider
    {
        ClaimsPrincipal GetPrincipal();
    }
}
