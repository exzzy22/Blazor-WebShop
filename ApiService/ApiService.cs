using Domain.Models;
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

    public async Task<ProductVM> GetProduct(int productId)
    {
        var response = await _httpClient.GetAsync($"api/product/{productId}");

        var product = await response.Content.ReadFromJsonAsync<ProductDto>();

        return _mapper.Map<ProductVM>(product);
    }

    public async Task<List<ProductVM>> GetProductsAsync()
    {
        var response = await _httpClient.GetAsync("api/product/all");

        var products = await response.Content.ReadFromJsonAsync<List<ProductDto>>();

        return _mapper.Map<List<ProductVM>>(products);
    }

    public async Task<CarouselVM> GetCarouselTopSelling(int numberOfCategories, int numberOfProducts)
    {
        var response = await _httpClient.GetAsync($"api/product/carousel/topSelling/{numberOfCategories}/{numberOfProducts}");

        var carousel = await response.Content.ReadFromJsonAsync<CarouselDto>();

        return _mapper.Map<CarouselVM>(carousel);
    }

    public async Task<List<AdminVM>> GetAdmins()
    {
        var response = await _httpClient.GetAsync("api/account/admin");

        var admins = await response.Content.ReadFromJsonAsync<List<AdminDto>>();

        return _mapper.Map<List<AdminVM>>(admins);
    }

    public async Task<bool> CreateAdmin(AdminForCreationVM admin)
    {
        var aa = _mapper.Map<AdminForCreationDto>(admin);
        var response = await _httpClient.PostAsJsonAsync("api/account/admin/new", _mapper.Map<AdminForCreationDto>(admin));

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAdmin(int adminId)
    {
        var response = await _httpClient.DeleteAsync($"api/account/admin/delete/{adminId}");

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAdmin(AdminVM admin)
    {
        var response = await _httpClient.PostAsJsonAsync("api/account/admin/edit", _mapper.Map<AdminDto>(admin));

        return response.IsSuccessStatusCode;
    }
}
