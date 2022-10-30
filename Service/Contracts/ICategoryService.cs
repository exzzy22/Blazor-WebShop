using System.Linq.Expressions;

namespace Service.Contracts;

public interface ICategoryService
{
    Task AddCategory(CategoryDto category);
    Task DeleteCategory(int categoryId);
    Task UpdateCategory(CategoryDto category);
    Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
}
