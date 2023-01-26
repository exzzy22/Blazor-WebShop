using Domain;

namespace Shared.RequestFeatures;

public class OrderParameters : RequestParameters
{
    public OrderFilter Filter { get; set; } = new();
}
