namespace Service.Contracts;

public interface ICurrencyService
{
    Task<CurrencyDto> GetCurrencyAsync(int currncyId);
    Task AddCurrencyAsync(CurrencyDto currency);
    Task DeleteCurrencyAsync(int currncyId);
    Task UpdateCurrencyAsync(CurrencyDto currency);
    Task<IEnumerable<CurrencyDto>> GetCurrenciesAsync();
}
