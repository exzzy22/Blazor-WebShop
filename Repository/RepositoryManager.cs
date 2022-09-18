using Repository.Contracts;
using Repository.Implementations;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IAttributesRepository> _attributesRepository;


        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));
            _attributesRepository = new Lazy<IAttributesRepository>(() => new AttributesRepository(repositoryContext));
        }

        public IProductRepository Product => _productRepository.Value;

        public ICategoryRepository Category => _categoryRepository.Value;

        public IAttributesRepository Attributes => _attributesRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
        public void Save() => _repositoryContext.SaveChanges();
    }
}