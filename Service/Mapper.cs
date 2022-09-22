namespace Service;

public class Mapper : Profile
{
	public Mapper()
	{
        CreateMap<ProductForCreationDto, Product>();
        CreateMap<Product, ProductCarouselDto>();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Attributes, AttributesDto>().IncludeAllDerived().ReverseMap();
        CreateMap<CpuAtrributes, CpuAtrributesDto>().ReverseMap();
        CreateMap<Price, PriceDto>().ReverseMap();
        CreateMap<Currency, CurrencyDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
