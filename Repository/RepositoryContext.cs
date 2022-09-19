using System.Diagnostics.Metrics;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User, Role, int>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.Entity<Product>()
                        .Navigation(p => p.Prices)
                        .AutoInclude(true);

            modelBuilder.Entity<Product>()
                        .HasOne(p => p.Attributes)
                        .WithOne(a => a.Product)
                        .HasForeignKey<Attributes>(p => p.ProductId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Attributes>()
                        .ToTable("Attributes")
                        .HasDiscriminator<int>("AttributesType")
                        .HasValue<Attributes>(0)
                        .HasValue<CpuAtrributes>(1);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Price> Prices { get; set; } = null!;
        public DbSet<Attributes> Attributes { get; set; } = null!;
        public DbSet<Currency> Currencies { get; set; } = null!;
    }
}