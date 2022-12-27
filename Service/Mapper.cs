using Microsoft.AspNetCore.Http;

namespace Service;

public class Mapper : Profile
{
	public Mapper()
	{
        CreateMap<AdminForCreationDto, User>();
        CreateMap<Product, ProductCarouselDto>()
						.ForMember(dest => dest.Image, opt => opt.MapFrom(soruce => soruce.Images.First(i => i.MainImage).File));
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
        CreateMap<ImageForCreationDto, Image>()
            .ForMember(dest => dest.File, opt => opt.MapFrom(soruce => soruce.ImageDataUrl));
        CreateMap<Image, ImageForCreationDto>()
            .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(soruce => soruce.File));
        CreateMap<ImageDto, Image>().ReverseMap();
        CreateMap<CurrencyForCreationDto, Currency>();
        CreateMap<PriceForCreationDto, Price>().ReverseMap();
        CreateMap<ProductForCreationDto, Product>().ReverseMap();
    }
}
