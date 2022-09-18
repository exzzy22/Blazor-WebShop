using AutoMapper;
using Shared.DataTransferObjects;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using ViewModels;

namespace ApiServices;

public sealed class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;

    public ApiService(IHttpClientFactory httpClientFactory, IMapper mapper)
    {
        _mapper = mapper;
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri("https://localhost:5000/");
    }

    public bool AuthenticationHeaderExits()
    {
        if(_httpClient?.DefaultRequestHeaders.Authorization is null)
            return false;
        
        return true;
    }

    public void SetAuthenticationHeader(string jwtToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", jwtToken);
    }

    public async Task<List<ProductVM>> GetProductsAsync()
    {
        var response = await _httpClient.GetAsync("api/product/all");
        var productsDtos = await response.Content.ReadFromJsonAsync<List<ProductForCreationDto>>();

        return _mapper.Map<List<ProductVM>>(productsDtos);
    }

    public async Task<List<CarouselVM>> GetCarouselTopSelling(int numberOfCategories, int numberOfProducts)
    {
        var response = await _httpClient.GetAsync($"api/product/carousel/topSelling/{numberOfCategories}/{numberOfProducts}");
        var carousel = await response.Content.ReadFromJsonAsync<List<CarouselDto>>();

        return _mapper.Map<List<CarouselVM>>(carousel);
    }
}
