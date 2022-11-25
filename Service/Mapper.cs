namespace Service;

public class Mapper : Profile
{
	public Mapper()
	{
        CreateMap<AdminForCreationDto, User>();
        CreateMap<Product, ProductCarouselDto>();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Attributes, AttributesDto>().IncludeAllDerived();
        CreateMap<AttributesDto, Attributes>().IncludeAllDerived();
        CreateMap<CpuAtrributes, CpuAtrributesDto>().ReverseMap();
        CreateMap<GpuAtrributes, GpuAtrributesDto>().ReverseMap();
        CreateMap<Price, PriceDto>().ReverseMap();
        CreateMap<Currency, CurrencyDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<User, AdminDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<PictureForCreationDto, Picture>()
            .ForMember(dest => dest.File, opt => opt.MapFrom(soruce => soruce.ImageDataUrl));
        CreateMap<PictureDto, Picture>().ReverseMap();
        CreateMap<CurrencyForCreationDto, Currency>();
        CreateMap<PriceForCreationDto, Price>();
        CreateMap<ProductForCreationDto, Product>();
    }
}
