namespace Repository.Implementations;

internal sealed class AttributesRepository : RepositoryBase<Attributes>, IAttributesRepository
{
    private readonly RepositoryContext _repositoryContext;

    public AttributesRepository(RepositoryContext repositoryContext) : base(repositoryContext) => _repositoryContext = repositoryContext;

    public new Attributes Create(Attributes attributes)
    { 
       _repositoryContext.Attributes.Add(attributes);
        return attributes;
    }
}
