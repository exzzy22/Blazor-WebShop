namespace Domain.Exceptions.ModelSpecific;

public sealed class UserNotFound : NotFoundException
{
    public UserNotFound() : base("User not found")
    {
    }
}
