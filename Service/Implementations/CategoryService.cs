using System.Text.Json;

namespace Service.Implementations;

internal sealed class CategoryService : ICategoryService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public CategoryService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }


    public async Task AddCategory(CategoryDto category)
    {
        Category categoryToInsert = _mapper.Map<Category>(category);
        _repository.Category.Create(categoryToInsert);
        await _repository.SaveAsync();
    }

    public async Task DeleteCategory(int categoryId)
    {
        Category category = await _repository.Category.GetCategoryAsync(categoryId,false) ?? throw new CategoryNotFound(categoryId);
        _repository.Category.DeleteCategory(category);
        await _repository.SaveAsync();
    }

    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
    {
        IEnumerable<Category> categories = await _repository.Category.GetCategoriesAsync();

        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task UpdateCategory(CategoryDto category) 
    {
        _repository.Category.UpdateCategory(_mapper.Map<Category>(category));
        await _repository.SaveAsync();
    }
}
