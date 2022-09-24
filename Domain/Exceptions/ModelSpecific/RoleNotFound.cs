namespace Domain.Exceptions.ModelSpecific;

public class RoleNotFound : NotFoundException
{
    public RoleNotFound(int id) : base($"Role with {id} not found")
    {
    }
}
