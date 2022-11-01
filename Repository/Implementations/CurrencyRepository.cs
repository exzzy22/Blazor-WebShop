namespace Repository.Implementations;

internal sealed class CurrencyRepository : RepositoryBase<Currency>, ICurrencyRepository
{
    public CurrencyRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }


    public async Task<Currency?> GetCurrencyAsync(int id, bool trackChanges) => await FindByCondition(c => c.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
    public async Task<IEnumerable<Currency>> GetCurrenciesAsync() => await FindAll(false).ToListAsync();
}
