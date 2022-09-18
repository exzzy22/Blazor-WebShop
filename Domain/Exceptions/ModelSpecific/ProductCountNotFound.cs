namespace Domain.Exceptions.ModelSpecific;

public sealed class ProductCountNotFound : NotFoundException
{
    public ProductCountNotFound(string categoryName) : base($"{categoryName} doesn't have 8 products"){}
}
