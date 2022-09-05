using Repository.Contracts;
using Repository.Implementations;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));
        }

        public IProductRepository Product => _productRepository.Value;

        public ICategoryRepository Category => _categoryRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
        public void Save() => _repositoryContext.SaveChanges();

    }
}