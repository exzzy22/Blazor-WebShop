namespace Service;

public class Mapper : Profile
{
	public Mapper()
	{
		CreateMap<Product, ProductForCreationDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Attribute, AttributesForCreationDto>().ReverseMap();
        CreateMap<CpuAtrributes, CpuAtrributesForCreationDto>().ReverseMap();
        CreateMap<Price, PriceForCreationDto>().ReverseMap();
        CreateMap<Currency, CurrencyDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
