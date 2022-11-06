﻿namespace ApiServices;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<ProductCarouselDto, ProductCarouselVM>().ReverseMap();
        CreateMap<CarouselDto, CarouselVM>().ReverseMap();
        CreateMap<CategoryDto, CategoryVM>().ReverseMap();
        CreateMap<ProductDto, ProductVM>().ReverseMap();
        CreateMap<PictureForCreationDto, PictureForCreationVM>().ReverseMap();
        CreateMap<PictureDto, PictureVM>().ReverseMap();
        CreateMap<AttributesDto, AttributesVM>().IncludeAllDerived();
        CreateMap<AttributesVM, AttributesDto>().IncludeAllDerived();
        CreateMap<CpuAtrributesDto, CpuAtrributesVM>().ReverseMap();
        CreateMap<PriceDto, PriceVM>().ReverseMap();
        CreateMap<CurrencyDto, CurrencyVM>().ReverseMap();
        CreateMap<AdminVM, AdminDto>().ReverseMap();
        CreateMap<AdminForCreationVM, AdminForCreationDto>().ReverseMap();
        CreateMap<UserDto, UserVM>();
        CreateMap<CurrencyVM, CurrencyForCreationDto>();
        CreateMap<PriceForCreationVM, PriceForCreationDto>();
        CreateMap<ProductForCreationVM, ProductForCreationDto>();
    }
}
