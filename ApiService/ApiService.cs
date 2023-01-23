using Domain.Exceptions.ModelSpecific;
using Domain.Models;
using Shared.DataTransferObjects;
using ViewModels;

namespace ApiServices;

public sealed class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;
    private string? _jwtToken;

    public ApiService(IHttpClientFactory httpClientFactory, IMapper mapper)
    {
        _mapper = mapper;
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri("https://localhost:5000/");
        if(_jwtToken is not null)
            SetAuthenticationHeader(_jwtToken);
    }

    public bool AuthenticationHeaderExits()
    {
        if(_httpClient?.DefaultRequestHeaders.Authorization is null)
            return false;
        
        return true;
    }

    public void SetAuthenticationHeader(string jwtToken)
    {
        _jwtToken = jwtToken;
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", jwtToken);
    }

    public void RemoveAuthenticationHeader()
    {
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }

    #region Products
    public async Task<ProductVM> GetProduct(int productId)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"api/product/{productId}");

        ProductDto product = await response.Content.ReadFromJsonAsync<ProductDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<ProductVM>(product);
    }

    public async Task<ProductForCreationVM> GetProductForUpdate(int productId)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"api/product/update/{productId}");

        ProductForCreationDto product = await response.Content.ReadFromJsonAsync<ProductForCreationDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<ProductForCreationVM>(product);
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

    public async Task<bool> UpdateProduct(ProductForCreationVM product)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/product/update/detailed", _mapper.Map<ProductForCreationDto>(product));

        return response.IsSuccessStatusCode;
    }

    public async Task<List<ProductVM>> GetProducts()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/product/all");

        List<ProductDto> products = await response.Content.ReadFromJsonAsync<List<ProductDto>>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<List<ProductVM>>(products);
    }

    public async Task<IEnumerable<ProductCarouselVM>> GetCarouselTopSelling(int numberOfProducts)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"api/product/carousel/topSelling/{numberOfProducts}");

		IEnumerable<ProductCarouselDto> carousel = await response.Content.ReadFromJsonAsync<IEnumerable<ProductCarouselDto>>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<IEnumerable<ProductCarouselVM>>(carousel);
    }

    public async Task<bool> DeleteImage(string image)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"api/product/image/delete",image);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteImage(List<string> images)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"api/product/image/delete/multiple",images);

        return response.IsSuccessStatusCode;
    }

    public async Task<List<ImageForTableVM>> GetUnusedImages()
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"api/product/image/unused");

        List<ImageForTableDto> imageForTable = await response.Content.ReadFromJsonAsync<List<ImageForTableDto>>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<List<ImageForTableVM>>(imageForTable);
    }

    #endregion

    #region Accounts
    public async Task<List<AdminVM>> GetAdmins()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/account/admin");

        List<AdminDto> admins = await response.Content.ReadFromJsonAsync<List<AdminDto>>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

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

    public async Task<bool> UpdateUser(UserVM user)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/account/user/edit", _mapper.Map<UserDto>(user));

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

        List<UserDto> admins = await response.Content.ReadFromJsonAsync<List<UserDto>>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<List<UserVM>>(admins);
    }

	public async Task<bool> Register(UserForRegistrationVM userForRegistration)
    {
		HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/account/user/new", _mapper.Map<UserForRegistrationDto>(userForRegistration));

		return response.IsSuccessStatusCode;
	}

	public async Task<(bool, TokenVM?)> Login(UserForAuthenticationVM userForAuthentication)
    {
		HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/account/login", _mapper.Map<UserForAuthenticationDto>(userForAuthentication));

        if (!response.IsSuccessStatusCode)
            return (false, null);

		TokenDto token = await response.Content.ReadFromJsonAsync<TokenDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return (true,_mapper.Map<TokenVM>(token));
	}

	public async Task<UserVM> GetLoggedUser()
	{
		HttpResponseMessage response = await _httpClient.GetAsync("api/account/user/logged");

		UserDto user = await response.Content.ReadFromJsonAsync<UserDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<UserVM>(user);
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

        List<CategoryDto> categories = await response.Content.ReadFromJsonAsync<List<CategoryDto>>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

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

        List<CurrencyDto> currencies = await response.Content.ReadFromJsonAsync<List<CurrencyDto>>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

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

	#region Cart

	public async Task<CartVM> AddProductToCart(int productId, int cartId, int quantity, int? userId = null)
    {
		HttpResponseMessage response = await _httpClient.GetAsync($"api/product/cart/add/{productId}/{cartId}/{quantity}/{userId}");

		CartDto cartResponse = await response.Content.ReadFromJsonAsync<CartDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<CartVM>(cartResponse);
	}
	public async Task<CartVM> RemoveProductFromCart(int productId, int cartId)
    {
		HttpResponseMessage response = await _httpClient.GetAsync($"api/product/cart/remove/{productId}/{cartId}");

		CartDto cartResponse = await response.Content.ReadFromJsonAsync<CartDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<CartVM>(cartResponse);
	}

	public async Task<CartVM> GetCart(int cartId)
	{
		HttpResponseMessage response = await _httpClient.GetAsync($"api/product/cart/{cartId}");

		CartDto cartResponse = await response.Content.ReadFromJsonAsync<CartDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<CartVM>(cartResponse);
	}
	public async Task<CartVM> JoinCartToUser(int cartId, int userId)
	{
		HttpResponseMessage response = await _httpClient.GetAsync($"api/product/cart/{cartId}/{userId}");

		CartDto cartResponse = await response.Content.ReadFromJsonAsync<CartDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<CartVM>(cartResponse);
	}
	#endregion

	#region Wishlist
	public async Task<WishlistVM> AddRemoveFromWishlist(int wishlistId, int productId, int? userId = null)
	{
		HttpResponseMessage response = await _httpClient.PostAsync($"api/product/wishlist/{wishlistId}/{productId}/{userId}", null);

		WishlistDto wishlist = await response.Content.ReadFromJsonAsync<WishlistDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<WishlistVM>(wishlist);
	}

	public async Task<WishlistVM> GetWishlist(int id)
	{
		HttpResponseMessage response = await _httpClient.GetAsync($"api/product/wishlist/{id}");

		WishlistDto wishlist = await response.Content.ReadFromJsonAsync<WishlistDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<WishlistVM>(wishlist);
	}

	public async Task<WishlistVM> JoinWishlistToUser(int wishlistId, int userId)
	{
		HttpResponseMessage response = await _httpClient.PostAsync($"api/product/wishlist/join/{wishlistId}/{userId}",null);

		WishlistDto wishlist = await response.Content.ReadFromJsonAsync<WishlistDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<WishlistVM>(wishlist);
	}
	#endregion

	#region Payment
	public async Task<string> CreatePayment(OrderVM order)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/payment/create", _mapper.Map<OrderDto>(order));

        string paymentUrl = await response.Content.ReadAsStringAsync() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

        return paymentUrl;
    }
	#endregion
}
