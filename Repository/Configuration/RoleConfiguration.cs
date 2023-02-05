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
                Name = "Super Administrator",
                NormalizedName = "Super Administrator".ToUpperInvariant(),
            },
            new Role
            {
                Id = 2,
                Name = "Administrator",
                NormalizedName = "Administrator".ToUpperInvariant(),
            },
            new Role
            {
                Id = 3,
                Name = "User",
                NormalizedName = "User".ToUpperInvariant(),
            }
        );
    }
}
