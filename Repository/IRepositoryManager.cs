using Repository.Contracts;

namespace Repository
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        IAttributesRepository Attributes { get; }

        Task SaveAsync();
        void Save();
    }
}