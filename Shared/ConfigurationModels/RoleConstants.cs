using Domain.Models;

namespace Shared.ConfigurationModels;

public class RoleConstants
{
    public Role SuperAdministrator = new Role { Id = 1, Name = "Super Administrator", };
    public Role Administrator = new Role { Id = 2, Name = "Administrator", };
    public Role User = new Role { Id = 3, Name = "User", };
}
