namespace WebShop;

public class UserState : INotifyPropertyChanged
{
	private UserVM? _user;
	private CartVM _cart = new();
	private readonly IApiService _apiService;
	private readonly ILocalStorageService _localStorageService;

	public UserState(IApiService apiService, ILocalStorageService localStorageService)
	{
		_apiService = apiService;
		_localStorageService = localStorageService;
	}

	public UserVM? User
	{
		get
		{
			return _user;
		}

		set
		{
			if (value != _user)
			{
				_user = value;
				NotifyPropertyChanged();
			}
		}
	}

	public CartVM Cart
	{
		get
		{
			return _cart;
		}

		set
		{
			if (value != _cart)
			{
				_cart = value;
				NotifyPropertyChanged();
			}
		}
	}


	public event PropertyChangedEventHandler? PropertyChanged;

	public async Task TryLoadData()
	{
		if (await _localStorageService.ContainKeyAsync("CartId"))
		{
			string cartID = await _localStorageService.GetItemAsStringAsync("CartId");
			Cart = await _apiService.GetCart(Convert.ToInt32(cartID));
		}
	}

	public async Task LoadUserData()
	{
		User = await _apiService.GetLoggedUser();
		if (Cart.Id != default)
		{
			Cart = await _apiService.JoinCartToUser(Cart.Id,User.Id);
		}
	}

	public async Task AddToCart(int productId, int quantity = 1) 
	{
		Cart = await _apiService.AddProductToCart(productId, Cart.Id, quantity,User is null ? null : User.Id);

		if (!await _localStorageService.ContainKeyAsync("CartId"))
		{
			await _localStorageService.SetItemAsStringAsync("CartId",Cart.Id.ToString());
		}
	}

	public async Task RemoveFromCart(int productId) 
	{
		Cart = await _apiService.RemoveProductFromCart(productId, Cart.Id);
	}

	private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
