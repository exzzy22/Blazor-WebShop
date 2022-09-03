namespace Shared.ConfigurationModels
{
    public class JwtConfiguration
    {
        public string Section { get; set; } = "JwtConfiguration";
        public string Secret { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
    }
}