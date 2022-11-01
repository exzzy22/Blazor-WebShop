namespace Service.Implementations;

internal sealed class CurrencyService : ICurrencyService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public CurrencyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
    public async Task AddCurrencyAsync(CurrencyDto currency)
    {
        Currency currencyToInsert = _mapper.Map<Currency>(currency);
        _repository.Currency.Create(currencyToInsert);
        await _repository.SaveAsync();
    }

    public async Task DeleteCurrencyAsync(int currncyId)
    {
        Currency currency = await _repository.Currency.GetCurrencyAsync(currncyId, false) ?? throw new CurrencyNotFound(currncyId);
        _repository.Currency.Delete(currency);
        await _repository.SaveAsync();
    }

    public async Task<IEnumerable<CurrencyDto>> GetCurrenciesAsync()
    {
        IEnumerable<Currency> currencies = await _repository.Currency.GetCurrenciesAsync();

        return _mapper.Map<IEnumerable<CurrencyDto>>(currencies);
    }

    public async Task<CurrencyDto> GetCurrencyAsync(int currncyId)
    {
        Currency currency = await _repository.Currency.GetCurrencyAsync(currncyId, false) ?? throw new CurrencyNotFound(currncyId);

        return _mapper.Map<CurrencyDto>(currency);
    }

    public async Task UpdateCurrencyAsync(CurrencyDto currency)
    {
        Currency dBcurrency = await _repository.Currency.GetCurrencyAsync(currency.Id, false) ?? throw new CurrencyNotFound(currency.Id);
        Currency updated = _mapper.Map(currency, dBcurrency);
        _repository.Currency.Update(updated);
        await _repository.SaveAsync();
    }
}
