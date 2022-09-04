namespace Service;

public class Mapper : Profile
{
	public Mapper()
	{
		CreateMap<Product, ProductDto>();
	}
}
