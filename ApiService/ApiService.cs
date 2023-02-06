using Domain.Models;
using Shared.ConfigurationModels.Configuration;

namespace ApiServices;

public sealed class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;
    private string? _jwtToken;
    private readonly WebShopConfiguration _configuration;

	public ApiService(IHttpClientFactory httpClientFactory, IMapper mapper, WebShopConfiguration configuration)
    {
        _configuration= configuration;
        _mapper = mapper;
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri(configuration.ApiBaseAddress);
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

		response.EnsureSuccessStatusCode();

		ProductDto product = await response.Content.ReadFromJsonAsync<ProductDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<ProductVM>(product);
    }

    public async Task<ProductForCreationVM> GetProductForUpdate(int productId)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"api/product/update/{productId}");

		response.EnsureSuccessStatusCode();

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

		response.EnsureSuccessStatusCode();

		List<ProductDto> products = await response.Content.ReadFromJsonAsync<List<ProductDto>>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<List<ProductVM>>(products);
    }

    public async Task<List<ProductVM>> GetProductsForCategory(int categoryId, int numberOfProducts)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"api/product/all/{categoryId}/{numberOfProducts}");

        response.EnsureSuccessStatusCode();

        List<ProductDto> products = await response.Content.ReadFromJsonAsync<List<ProductDto>>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<List<ProductVM>>(products);
    }

    public async Task<ProductPagedList<ProductVM>> GetProducts(ProductParameters productParameters)
	{
		HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"api/product",productParameters);

		response.EnsureSuccessStatusCode();

		ProductPagedList<ProductDto> products = await response.Content.ReadFromJsonAsync<ProductPagedList<ProductDto>>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<ProductPagedList<ProductVM>>(products);
	}

	public async Task<IEnumerable<ProductCarouselVM>> GetCarouselTopSelling(int numberOfProducts)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"api/product/carousel/topSelling/{numberOfProducts}");

		response.EnsureSuccessStatusCode();

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

		response.EnsureSuccessStatusCode();

		List<ImageForTableDto> imageForTable = await response.Content.ReadFromJsonAsync<List<ImageForTableDto>>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<List<ImageForTableVM>>(imageForTable);
    }

	public async Task<PagedList<ReviewVM>> GetReviews(ReviewParameters reviewParameters)
	{
		HttpResponseMessage response = await _httpClient.GetAsync($"api/product/review{reviewParameters.ToQueryString()}");

		response.EnsureSuccessStatusCode();

		PagedList<ReviewDto> reviews = await response.Content.ReadFromJsonAsync<PagedList<ReviewDto>>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<PagedList<ReviewVM>>(reviews);
	}

	public async Task<bool> SubmitReview(SubmitReviewVM reviewVM)
	{
		HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/product/review/submit",reviewVM);

        return response.IsSuccessStatusCode;
	}
	#endregion

	#region Accounts
	public async Task<List<AdminVM>> GetAdmins()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/account/admin");

		response.EnsureSuccessStatusCode();

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

		response.EnsureSuccessStatusCode();

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

		response.EnsureSuccessStatusCode();

		UserDto user = await response.Content.ReadFromJsonAsync<UserDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<UserVM>(user);
	}

	public async Task<bool> ChangePassword(ChangePasswordVM changePassword)
	{
		HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/account/user/changePassword", _mapper.Map<ChangePasswordDto>(changePassword));

		return response.IsSuccessStatusCode;
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

		response.EnsureSuccessStatusCode();

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

		response.EnsureSuccessStatusCode();

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
		HttpResponseMessage response = await _httpClient.PostAsync($"api/product/cart/add/{productId}/{cartId}/{quantity}/{userId}",null);

		response.EnsureSuccessStatusCode();

		CartDto cartResponse = await response.Content.ReadFromJsonAsync<CartDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<CartVM>(cartResponse);
	}
	public async Task<CartVM> RemoveProductFromCart(int productId, int cartId)
    {
		HttpResponseMessage response = await _httpClient.PostAsync($"api/product/cart/remove/{productId}/{cartId}", null);

		response.EnsureSuccessStatusCode();

		CartDto cartResponse = await response.Content.ReadFromJsonAsync<CartDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<CartVM>(cartResponse);
	}

	public async Task<CartVM> GetCart(int cartId)
	{
		HttpResponseMessage response = await _httpClient.GetAsync($"api/product/cart/{cartId}");

		response.EnsureSuccessStatusCode();

		CartDto cartResponse = await response.Content.ReadFromJsonAsync<CartDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<CartVM>(cartResponse);
	}

    public async Task<CartVM> GetUserCart(int userId)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"api/product/cart/user/{userId}");

		response.EnsureSuccessStatusCode();

		CartDto cartResponse = await response.Content.ReadFromJsonAsync<CartDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<CartVM>(cartResponse);
    }

    public async Task<CartVM> ClearCart(int cartId)
    {
        HttpResponseMessage response = await _httpClient.PostAsync($"api/product/cart/clear/{cartId}", null);

		response.EnsureSuccessStatusCode();

		CartDto cartResponse = await response.Content.ReadFromJsonAsync<CartDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<CartVM>(cartResponse);
    }

    public async Task<CartVM> JoinCartToUser(int cartId, int userId)
	{
		HttpResponseMessage response = await _httpClient.GetAsync($"api/product/cart/{cartId}/{userId}");

		response.EnsureSuccessStatusCode();

		CartDto cartResponse = await response.Content.ReadFromJsonAsync<CartDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<CartVM>(cartResponse);
	}
	#endregion

	#region Wishlist
	public async Task<WishlistVM> AddRemoveFromWishlist(int wishlistId, int productId, int? userId = null)
	{
		HttpResponseMessage response = await _httpClient.PostAsync($"api/product/wishlist/{wishlistId}/{productId}/{userId}", null);

		response.EnsureSuccessStatusCode();

		WishlistDto wishlist = await response.Content.ReadFromJsonAsync<WishlistDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<WishlistVM>(wishlist);
	}

	public async Task<WishlistVM> GetWishlist(int id)
	{
		HttpResponseMessage response = await _httpClient.GetAsync($"api/product/wishlist/{id}");

		response.EnsureSuccessStatusCode();

		WishlistDto wishlist = await response.Content.ReadFromJsonAsync<WishlistDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<WishlistVM>(wishlist);
	}

    public async Task<WishlistVM> GetUserWishlist(int userId)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"api/product/wishlist/user/{userId}");

		response.EnsureSuccessStatusCode();

		WishlistDto wishlist = await response.Content.ReadFromJsonAsync<WishlistDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

        return _mapper.Map<WishlistVM>(wishlist);
    }

    public async Task<WishlistVM> JoinWishlistToUser(int wishlistId, int userId)
	{
		HttpResponseMessage response = await _httpClient.PostAsync($"api/product/wishlist/join/{wishlistId}/{userId}",null);

		response.EnsureSuccessStatusCode();

		WishlistDto wishlist = await response.Content.ReadFromJsonAsync<WishlistDto>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<WishlistVM>(wishlist);
	}
	#endregion

	#region Payment
	public async Task<string> CreatePayment(OrderForCreationVM order)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/payment/create", _mapper.Map<OrderForCreationDto>(order));

		response.EnsureSuccessStatusCode();

		return await response.Content.ReadAsStringAsync() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());
    }

    public async Task<bool> ValidatePayment(int orderId, string sessionId)
    {
        HttpResponseMessage response = await _httpClient.PostAsync($"api/payment/validate/{orderId}/{sessionId}", null);

        return response.IsSuccessStatusCode;
    }
    #endregion

    #region Orders
    public async Task<PagedList<OrderVM>> GetOrders(OrderParameters orderParameters)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"api/order/page{orderParameters.ToQueryString()}");

		response.EnsureSuccessStatusCode();

		PagedList<OrderDto> orders = await response.Content.ReadFromJsonAsync<PagedList<OrderDto>>() ?? throw new JsonParsingException(await response.Content.ReadAsStringAsync());

		return _mapper.Map<PagedList<OrderVM>>(orders);
    }

    public async Task<string> GetInvoice(string invoiceId)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"api/order/invoice/{invoiceId}");

		response.EnsureSuccessStatusCode();

		response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
	#endregion

	#region Newsletter

	public async Task<bool> SubscribeNewsLetter(string email)
    {
		HttpResponseMessage response = await _httpClient.PostAsync($"api/account/newsLetter/subscribe/{email}", null);

        return response.IsSuccessStatusCode;
	}
	#endregion
}
