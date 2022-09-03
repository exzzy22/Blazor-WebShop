using Repository.Contracts;

namespace Repository
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }

        Task SaveAsync();
        void Save();
    }
}