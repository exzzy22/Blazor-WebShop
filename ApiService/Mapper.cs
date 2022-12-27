namespace ApiServices;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<ProductCarouselDto, ProductCarouselVM>().ReverseMap();
        CreateMap<CarouselDto, CarouselVM>().ReverseMap();
        CreateMap<CategoryDto, CategoryVM>().ReverseMap();
        CreateMap<ProductDto, ProductVM>().ReverseMap();
        CreateMap<ImageForCreationDto, ImageForCreationVM>().ReverseMap();
        CreateMap<ImageDto, ImageVM>().ReverseMap();
        CreateMap<AttributesDto, AttributesVM>().IncludeAllDerived();
        CreateMap<AttributesVM, AttributesDto>().IncludeAllDerived();
        CreateMap<CpuAtrributesDto, CpuAtrributesVM>().ReverseMap();
        CreateMap<GpuAtrributesDto, GpuAtrributesVM>().ReverseMap();
        CreateMap<PriceDto, PriceVM>().ReverseMap();
        CreateMap<CurrencyDto, CurrencyVM>().ReverseMap();
        CreateMap<AdminVM, AdminDto>().ReverseMap();
        CreateMap<AdminForCreationVM, AdminForCreationDto>().ReverseMap();
        CreateMap<UserDto, UserVM>();
        CreateMap<CurrencyVM, CurrencyForCreationDto>();
        CreateMap<PriceForCreationVM, PriceForCreationDto>().ReverseMap();
        CreateMap<ProductForCreationVM, ProductForCreationDto>().ReverseMap();
        CreateMap<ImageForTableDto, ImageForTableVM>().ReverseMap();
    }
}
