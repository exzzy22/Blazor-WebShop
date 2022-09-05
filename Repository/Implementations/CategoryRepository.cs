﻿namespace Repository.Implementations;

internal sealed class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    private readonly RepositoryContext _repositoryContext;
    public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext) => _repositoryContext = repositoryContext;

    public void DeleteCategory(Category category) => Delete(category);

    public async Task<Category> GetCategoryAsync(int id, bool trackChanges) => await FindByCondition(p => p.Id.Equals(id), trackChanges).FirstOrDefaultAsync();

    public IEnumerable<Category> GetTopCategoriesAsync<T>(Expression<Func<Product, T>> orderBy, int take) => _repositoryContext.Products
        .Include(p => p.SubCategory)
        .ThenInclude(s => s.Category)
        .OrderByDescending(orderBy)
        .Take(take)
        .Select(p => p.SubCategory.Category);

    public void UpdateCategory(Category category) => Update(category);
}
