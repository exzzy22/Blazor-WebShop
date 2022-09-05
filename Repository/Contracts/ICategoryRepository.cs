namespace Repository.Contracts;

public interface ICategoryRepository
{
    Task<Category> GetCategoryAsync(int id, bool trackChanges);
    void UpdateCategory(Category category);
    void DeleteCategory(Category category);
    IEnumerable<Category> GetTopCategoriesAsync<T>(Expression<Func<Product, T>> orderBy, int take);
}
