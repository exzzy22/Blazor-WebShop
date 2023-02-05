namespace Repository.Implementations;

internal sealed class ProductRepository : RepositoryBase<Product> , IProductRepository
{
    private readonly RepositoryContext _repositoryContext;
    public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext) => _repositoryContext = repositoryContext;

    public async Task<Product?> GetProductAsync(int id, bool trackChanges, bool ignoreAutoIncludes = false) =>
        !ignoreAutoIncludes ?
        await FindByCondition(p => p.Id.Equals(id), trackChanges)
        .Include(p => p.Category)
        .Include(p => p.Attributes)
        .Include(p => p.Images)
        .FirstOrDefaultAsync()
        :
        await FindByCondition(p => p.Id.Equals(id), trackChanges)
        .Include(p => p.Category)
        .Include(p => p.Attributes)
        .Include(p => p.Images)
        .IgnoreAutoIncludes()
		.FirstOrDefaultAsync();


	public async Task<IEnumerable<Product>> GetProductsAsync() => await FindAll(false)
        .Include(p => p.Category)
        .Include(p => p.Attributes)
        .Include(p => p.Images)
        .ToListAsync();

    public async Task<IEnumerable<Product>> GetProductsForCategoryAsync(int categoryId, int numberOfProducts) => await FindAll(false)
		.Include(p => p.Images)
		.Where(p => p.CategoryId == categoryId)
        .Take(numberOfProducts)
        .ToListAsync();

    public async Task<IEnumerable<Product>> GetProductsAsync<T>(Expression<Func<Product, T>> orderBy, int numberOfProducts) =>
        await FindAll(false)
	    .Include(p => p.Category)
	    .Include(p => p.Attributes)
	    .Include(p => p.Images)
        .OrderBy(orderBy)
        .Take(numberOfProducts)
	    .ToListAsync();

	public async Task<ProductPagedList<Product>> GetProductsAsync(ProductParameters productParameters)
	{
        var products = _repositoryContext.Products.AsQueryable();


		Dictionary<int,int> categoryCount = new ();
        Dictionary<string,int> manufacturerCount = new ();

        foreach (int categoryId in products.Select(p => p.CategoryId).Distinct().ToList())
        {
            categoryCount.Add(categoryId,products.Count(p => p.CategoryId == categoryId));
        }

		foreach (string manufacturer in products.Select(p => p.Attributes.Manufacturer).Distinct().ToList())
		{
			manufacturerCount.Add(manufacturer, products.Count(p => p.Attributes.Manufacturer.Equals(manufacturer)));
		}

		products = products.FilterProducts(productParameters.Filter)
			.Include(p => p.Category)
			.Include(p => p.Images);

        if (productParameters.OrderBy is not null && productParameters.OrderBy.Contains("price", StringComparison.OrdinalIgnoreCase))
        {
            products = products.SortByPrice(productParameters.OrderBy,productParameters.Filter.CurrencyId);

        }
        else
        {
            products = products.Sort(productParameters.OrderBy);
		}


		return ProductPagedList<Product>.ToProductPagedList(await products.ToListAsync(), productParameters.PageNumber, productParameters.PageSize,categoryCount, manufacturerCount);
	}
}
