namespace Shared.ConfigurationModels.Configuration;

public class Configuration
{
    public FilePathConfiguration FilePathConfiguration { get; set; } = null!;

    public Stripe Stripe { get; set; } = null!;
    public BaseUrls BaseUrls { get; set; } = null!;
}
