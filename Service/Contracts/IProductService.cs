namespace Service.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProductsAsync();
}
