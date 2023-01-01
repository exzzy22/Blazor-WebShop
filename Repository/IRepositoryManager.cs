using Repository.Contracts;

namespace Repository
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        IAttributesRepository Attributes { get; }
        ICurrencyRepository Currency { get; }
        IImageRepository Image { get; }
        ICartRepository Cart { get; }
        IOrderRepository Order { get; }


        Task SaveAsync();
        void Save();
    }
}