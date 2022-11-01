namespace Repository.Contracts;

public interface ICurrencyRepository
{
    void Create(Currency product);
    Task<Currency?> GetCurrencyAsync(int id, bool trackChanges);
    void Update(Currency product);
    void Delete(Currency product);
    Task<IEnumerable<Currency>> GetCurrenciesAsync();
}
