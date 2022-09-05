namespace Service;

public class Mapper : Profile
{
	public Mapper()
	{
		CreateMap<Product, ProductDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<SubCategory, SubCategoryDto>();
    }
}
