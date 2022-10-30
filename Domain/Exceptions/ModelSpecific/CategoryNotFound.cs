namespace Domain.Exceptions.ModelSpecific;

public class CategoryNotFound : NotFoundException
{
    public CategoryNotFound(int id) : base($"Category with {id} not found")
    {
    }
}
