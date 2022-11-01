namespace Domain.Exceptions.ModelSpecific;

public class CurrencyNotFound : NotFoundException
{
    public CurrencyNotFound(int id) : base($"Currency with {id} not found")
    {
    }
}
