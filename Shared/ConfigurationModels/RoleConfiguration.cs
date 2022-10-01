using Domain.Models;

namespace Shared.ConfigurationModels;

public static class RoleConfiguration
{
    public static readonly Role SuperAdministrator = new Role { Id = 1, Name = "Super Administrator", };
    public static readonly Role Administrator = new Role { Id = 2, Name = "Administrator", };
    public static readonly Role User = new Role { Id = 3, Name = "User", };
}
