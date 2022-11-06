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

    #region Products
    public async Task<ProductVM> GetProduct(int productId)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"api/product/{productId}");

        ProductDto product = await response.Content.ReadFromJsonAsync<ProductDto>() ?? throw new NullReferenceException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<ProductVM>(product);
    }

    public async Task<bool> AddProduct(ProductForCreationVM product)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/product/add", _mapper.Map<ProductForCreationDto>(product));

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync($"api/product/delete/{productId}");

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateProduct(ProductVM product)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/product/update", _mapper.Map<ProductVM>(product));

        return response.IsSuccessStatusCode;
    }

    public async Task<List<ProductVM>> GetProducts()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/product/all");

        List<ProductDto> products = await response.Content.ReadFromJsonAsync<List<ProductDto>>() ?? throw new NullReferenceException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<List<ProductVM>>(products);
    }

    public async Task<CarouselVM> GetCarouselTopSelling(int numberOfCategories, int numberOfProducts)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"api/product/carousel/topSelling/{numberOfCategories}/{numberOfProducts}");

        CarouselDto carousel = await response.Content.ReadFromJsonAsync<CarouselDto>() ?? throw new NullReferenceException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<CarouselVM>(carousel);
    }
    #endregion

    #region Accounts
    public async Task<List<AdminVM>> GetAdmins()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/account/admin");

        List<AdminDto> admins = await response.Content.ReadFromJsonAsync<List<AdminDto>>() ?? throw new NullReferenceException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<List<AdminVM>>(admins);
    }

    public async Task<bool> CreateAdmin(AdminForCreationVM admin)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/account/admin/new", _mapper.Map<AdminForCreationDto>(admin));

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAdmin(int adminId)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync($"api/account/admin/delete/{adminId}");

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAdmin(AdminVM admin)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/account/admin/edit", _mapper.Map<AdminDto>(admin));

        return response.IsSuccessStatusCode;
    }

    public async Task<List<UserVM>> GetUsers()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/account/user");

        List<UserDto> admins = await response.Content.ReadFromJsonAsync<List<UserDto>>() ?? throw new NullReferenceException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<List<UserVM>>(admins);
    }
    #endregion

    #region Category
    public async Task<bool> AddCategory(CategoryVM category)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/product/category/add", _mapper.Map<CategoryDto>(category));

        return response.IsSuccessStatusCode;
    }

    public async Task<List<CategoryVM>> GetCategories()
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"api/product/category/all");

        List<CategoryDto> categories = await response.Content.ReadFromJsonAsync<List<CategoryDto>>() ?? throw new NullReferenceException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<List<CategoryVM>>(categories);
    }

    public async Task<bool> DeleteCategory(int categoryId)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync($"api/product/category/delete/{categoryId}");

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateCategory(CategoryVM category)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/product/category/update", _mapper.Map<CategoryDto>(category));

        return response.IsSuccessStatusCode;
    }

    #endregion

    #region Currency
    public async Task<bool> AddCurrency(CurrencyDto currency)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/product/currency/add", _mapper.Map<CurrencyDto>(currency));

        return response.IsSuccessStatusCode;
    }

    public async Task<List<CurrencyVM>> GetCurrencies()
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"api/product/currency/all");

        List<CurrencyDto> currencies = await response.Content.ReadFromJsonAsync<List<CurrencyDto>>() ?? throw new NullReferenceException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<List<CurrencyVM>>(currencies);
    }

    public async Task<bool> DeleteCurrency(int currencyId)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync($"api/product/currency/delete/{currencyId}");

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateCurrency(CurrencyVM currency)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/product/currency/update", _mapper.Map<CurrencyDto>(currency));

        return response.IsSuccessStatusCode;
    }

    #endregion
}
