namespace Repository.Implementations;

internal sealed class ImageRepository : RepositoryBase<Image>, IImageRepository
{
    private readonly RepositoryContext _repositoryContext;
    public ImageRepository(RepositoryContext repositoryContext) : base(repositoryContext) => _repositoryContext = repositoryContext;

    public async Task<List<Image>> GetAllImages(bool trackchanges) => await FindAll(trackchanges).ToListAsync();
}
