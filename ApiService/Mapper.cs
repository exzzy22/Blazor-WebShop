namespace ApiServices;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<ProductForCreationDto, ProductVM>().ReverseMap();
        CreateMap<ProductCarouselDto, ProductCarouselVM>().ReverseMap();
        CreateMap<CarouselDto, CarouselVM>().ReverseMap();
        CreateMap<CategoryDto, CategoryVM>().ReverseMap();
        CreateMap<ProductDto, ProductVM>().ReverseMap();
        CreateMap<AttributesDto, AttributesVM>().IncludeAllDerived().ReverseMap();
        CreateMap<CpuAtrributesDto, CpuAtrributesVM>().ReverseMap();
        CreateMap<PriceDto, PriceVM>().ReverseMap();
        CreateMap<CurrencyDto, CurrencyVM>().ReverseMap();
        CreateMap<AdminVM, AdminDto>().ReverseMap();
        CreateMap<AdminForCreationVM, AdminForCreationDto>().ReverseMap();
        CreateMap<UserDto, UserVM>();
    }
}
