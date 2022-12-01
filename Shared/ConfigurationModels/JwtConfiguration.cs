namespace Shared.ConfigurationModels
{
    public class JwtConfiguration
    {
        public string Section { get; set; } = "JwtConfiguration";
        public string Secret { get; set; } = null!;
        public string ValidIssuer { get; set; } = null!;
        public string ValidAudience { get; set; } = null!;
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
    }
}