using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData
        (
            new Role 
            { 
                Id = 1,
                Name = "Administrator",
            },
            new Role
            {
                Id = 2,
                Name = "User",
            }
        );
    }
}
