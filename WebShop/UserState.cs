namespace WebShop;

public class UserState : INotifyPropertyChanged
{
	private UserVM? _user;
	private CartVM _cart = new();
	private WishlistVM _wishlist = new();
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

	public WishlistVM Wishlist
	{
		get
		{
			return _wishlist;
		}

		set
		{
			if (value != _wishlist)
			{
				_wishlist = value;
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
		else if (User is not null)
		{ 
			CartVM? cart = await _apiService.GetUserCart(User.Id);
			if (cart is not null)
			{
				Cart = cart;
                await _localStorageService.SetItemAsStringAsync("CartId", Cart.Id.ToString());
            }
        }

		if (await _localStorageService.ContainKeyAsync("WishlistId"))
		{
			string wishlistID = await _localStorageService.GetItemAsStringAsync("WishlistId");
			Wishlist = await _apiService.GetWishlist(Convert.ToInt32(wishlistID));
		}
		else if (User is not null)
		{
            WishlistVM? wishlist = await _apiService.GetUserWishlist(User.Id);
			if (wishlist is not null)
			{
				Wishlist = wishlist;
                await _localStorageService.SetItemAsStringAsync("WishlistId", Wishlist.Id.ToString());
            }
        }
    }

	public async Task LoadUserData()
	{
		User = await _apiService.GetLoggedUser();
		if (Cart.Id != default)
		{
			Cart = await _apiService.JoinCartToUser(Cart.Id,User.Id);
            await _localStorageService.SetItemAsStringAsync("CartId", Cart.Id.ToString());
        }

		if (Wishlist.Id != default)
		{
			Wishlist = await _apiService.JoinWishlistToUser(Wishlist.Id, User.Id);
            await _localStorageService.SetItemAsStringAsync("WishlistId", Wishlist.Id.ToString());
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

	public async Task RemoveFromCart(int productId) => Cart = await _apiService.RemoveProductFromCart(productId, Cart.Id);

    public async Task ClearCart() => Cart = await _apiService.ClearCart(Cart.Id);

    public async Task AddRemoveFromWishlist(int productId)
	{
		Wishlist = await _apiService.AddRemoveFromWishlist(Wishlist.Id,productId,User is null ? null : User.Id);

		if (!await _localStorageService.ContainKeyAsync("WishlistId"))
		{
			await _localStorageService.SetItemAsStringAsync("WishlistId", Wishlist.Id.ToString());
		}
	}

	private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
