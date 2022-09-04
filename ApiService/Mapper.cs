using AutoMapper;
using Domain.Models;
using Shared.DataTransferObjects;
using ViewModels;

namespace ApiServices;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<ProductDto, ProductVM>();
    }
}
