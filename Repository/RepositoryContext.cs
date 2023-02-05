namespace Repository;

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

        modelBuilder.Entity<Price>()
                    .Navigation(p => p.Currency)
                    .AutoInclude(true);

        modelBuilder.Entity<Product>()
                    .HasOne(p => p.Attributes)
                    .WithOne(a => a.Product)
                    .HasForeignKey<Attributes>(p => p.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<Review>()
                    .Property(r => r.CreatedDate)
					.HasColumnType("datetime2")
					.HasDefaultValueSql("(getdate())");

		modelBuilder.Entity<Attributes>()
                    .ToTable("Attributes")
                    .HasDiscriminator<int>("AttributesType")
                    .HasValue<Attributes>(0)
                    .HasValue<CpuAtrributes>(1)
                    .HasValue<GpuAtrributes>(2);

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(o => o.BillingAddress)
                .WithOne(a => a.BillingOrder)
                .HasForeignKey<Address>(a => a.BillingOrderId);

            entity.HasOne(o => o.ShippingAddress)
                .WithOne(a => a.ShippingOrder)
                .HasForeignKey<Address>(a => a.ShippingOrderId);

            entity.Property(e => e.CratedDate)
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("(getdate())");
        });


        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Price> Prices { get; set; } = null!;
    public DbSet<Attributes> Attributes { get; set; } = null!;
    public DbSet<Currency> Currencies { get; set; } = null!;
    public DbSet<Image> Images { get; set; } = null!;
    public DbSet<Cart> Carts { get; set; } = null!;
    public DbSet<Wishlist> Wishlists { get; set; } = null!;
	public DbSet<Order> Orders { get; set; } = null!;
	public DbSet<Address> Adresses { get; set; } = null!;
    public DbSet<ProductOrder> ProductOrders { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
	public DbSet<Newsletter> Newsletters { get; set; } = null!;
}