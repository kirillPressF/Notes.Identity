using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace Notes.Identity
{

    public class Configuration
    {
        public static IEnumerable<ApiScope> GetApiScope() =>
            new List<ApiScope>
            {
                new ApiScope("notes.api", "Notes API")
            };

        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> GetApiResources() =>
            new List<ApiResource>
            {
                new ApiResource("notes.api", "Notes API", new[] {JwtClaimTypes.Name})
                {
                    Scopes = {"notes.api"}

                }
            };

        public static IEnumerable<Client> Get() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "notes.api.client",
                    ClientName = "Notes API Client",

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowOfflineAccess = true,
                    RequireClientSecret = false,
                    RequirePkce = true,

                    RedirectUris = new List<string>
                    {
                        "https://localhost:5002/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:5002/signout-callback-oidc"
                    },
                    FrontChannelLogoutUri = "https://localhost:5002/signout-oidc",

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "notes.api"
                    },
                    AllowedCorsOrigins = {"https://localhost:5002"},
                }
            };
    }
}