namespace ApiServices;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<ProductForCreationDto, ProductVM>().ReverseMap();
        CreateMap<CarouselDto, CarouselVM>().ReverseMap();
        CreateMap<CategoryDto, CategoryVM>().ReverseMap();
    }
}
