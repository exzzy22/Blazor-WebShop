namespace Shared.ConfigurationModels.Configuration;

public class Stripe
{
    public string PubKey { get; set; } = null!;
    public string SecretKey { get; set; } = null!;
}
