namespace Domain.Exceptions.ModelSpecific;

public sealed class ProductCountNotFound : NotFoundException
{
    public ProductCountNotFound(string categoryName, int numberOfProducts) : base($"{categoryName} doesn't have {numberOfProducts} products"){}
}
