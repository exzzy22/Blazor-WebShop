namespace Service;

public class Mapper : Profile
{
	public Mapper()
	{
        CreateMap<AdminForCreationDto, User>();
        CreateMap<Product, ProductCarouselDto>();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Attributes, AttributesDto>().IncludeAllDerived().ReverseMap();
        CreateMap<CpuAtrributes, CpuAtrributesDto>().ReverseMap();
        CreateMap<Price, PriceDto>().ReverseMap();
        CreateMap<Currency, CurrencyDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<User, AdminDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}
