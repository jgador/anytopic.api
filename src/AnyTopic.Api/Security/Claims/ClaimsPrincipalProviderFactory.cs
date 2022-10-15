using EnsureThat;

namespace AnyTopic.Api.Security.Claims
{
    public static class ClaimsPrincipalProviderFactory
    {
        private static IClaimsPrincipalProvider? _claimsPrincipalProvider = null;

        internal static void SetClaimsPrincipalProvider(IClaimsPrincipalProvider provider)
        {
            EnsureArg.IsNotNull(provider, nameof(provider));

            _claimsPrincipalProvider = provider;
        }

        public static IClaimsPrincipalProvider GetClaimsPrincipalProvider() => _claimsPrincipalProvider!;
    }
}
