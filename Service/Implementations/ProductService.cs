namespace Service.Implementations;

internal sealed class ProductService : IProductService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _accessor;
    private readonly Configuration _configuration;
    private readonly string _imagePath;
    public ProductService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor accessor, IOptions<Configuration> configuration)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _webHostEnvironment = webHostEnvironment;
        _configuration = configuration.Value;
        _imagePath = webHostEnvironment.WebRootPath + _configuration.FilePathConfiguration.Image;
        _accessor = accessor;
    }

    public async Task<ProductDto> GetProductAsync(int productId)
    {
        Product product = await _repository.Product.GetProductAsync(productId, false) ?? throw new ProductNotFound(productId);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task AddProductAsync(ProductForCreationDto product)
    {
        // Switch ImageDataUrl with saved file name
        foreach (ImageForCreationDto image in product.Images)
        {
            image.ImageDataUrl = image.ImageDataUrl.SaveDataUrlToFile($"{_imagePath}{Guid.NewGuid()}{image.FileExtension}");
        }

        Product productToInsert = _mapper.Map<Product>(product);
        _repository.Product.Create(productToInsert);

        await _repository.SaveAsync();
    }

    public async Task DeleteProductAsync(int productId)
    {
        Product product = await _repository.Product.GetProductAsync(productId, false) ?? throw new ProductNotFound(productId);
        _repository.Product.Delete(product);
        await _repository.SaveAsync();
    }
    public async Task UpdateProductAsync(ProductForCreationDto product)
    {
        if (product.Id is null)
            throw new ProductNotFound();

        // Switch ImageDataUrl with saved file name
        foreach (ImageForCreationDto image in product.Images)
        {
            if (!image.ImageDataUrl.StartsWith("http"))
                image.ImageDataUrl = image.ImageDataUrl.SaveDataUrlToFile($"{_imagePath}{Guid.NewGuid()}{image.FileExtension}");

            else
                image.ImageDataUrl = image.ImageDataUrl.Split("image/")[1];
        }

        Product dBproduct = await _repository.Product.GetProductAsync((int)product.Id, true) ?? throw new ProductNotFound((int)product.Id);
        Product updated = _mapper.Map(product, dBproduct);
        _repository.Product.Update(updated);
        await _repository.SaveAsync();

    }

    public async Task UpdateProductAsync(ProductDto product)
    {
        Product dBproduct = await _repository.Product.GetProductAsync(product.Id, false) ?? throw new ProductNotFound(product.Id);
        Product updated = _mapper.Map(product, dBproduct);
        _repository.Product.Update(updated);
        await _repository.SaveAsync();
    }
    public async Task<IEnumerable<ProductCarouselDto>> GetCarouselProductsAsync<T>(Expression<Func<Product, T>> orderBy, int numberOfProducts)
    {
        IEnumerable<ProductCarouselDto> products = _mapper.Map<IEnumerable<ProductCarouselDto>>(await _repository.Product.GetProductsAsync(orderBy, numberOfProducts));

		foreach (ProductCarouselDto product in products)
		{
			product.AvgStarRating = _repository.Review.GetProductAvgRating(product.Id);
		}


        return products;
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        IEnumerable<Product> products = await _repository.Product.GetProductsAsync();

        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsForCategoryAsync(int categoryId, int numberOfProducts)
    {
        IEnumerable<ProductDto> products = _mapper.Map<IEnumerable<ProductDto>>(await _repository.Product.GetProductsForCategoryAsync(categoryId, numberOfProducts));

        foreach (ProductDto product in products)
        {
            product.AvgStarRating = _repository.Review.GetProductAvgRating(product.Id);
        }

        return products;
    }

    public async Task<ProductPagedList<ProductDto>> GetProductsAsync(ProductParameters productParameters)
    {
        ProductPagedList<ProductDto> products = _mapper.Map<ProductPagedList<ProductDto>>(await _repository.Product.GetProductsAsync(productParameters));

		foreach (ProductDto product in products.Items)
		{
			product.AvgStarRating = _repository.Review.GetProductAvgRating(product.Id);
		}

        return products;
	}
	public async Task<ProductForCreationDto> GetProductForUpdateAsync(int productId)
    {
        Product product = await _repository.Product.GetProductAsync(productId, false) ?? throw new ProductNotFound(productId);

        ProductForCreationDto productForCreation = _mapper.Map<ProductForCreationDto>(product);

        foreach (var image in productForCreation.Images)
        {
            image.ImageDataUrl = $"{_accessor?.HttpContext?.Request.Scheme}://{_accessor?.HttpContext?.Request.Host}{_accessor?.HttpContext?.Request.PathBase}/image/{image.ImageDataUrl}";
        }

        return productForCreation;
    }

    public void DeleteImage(string name)
    {
        if (File.Exists(_imagePath + name))
        {
            File.Delete(_imagePath + name);
        }
    }

    public void DeleteImage(List<string> names)
    {
        foreach (string name in names)
        {
            if (File.Exists(_imagePath + name))
            {
                File.Delete(_imagePath + name);
            }
        }
    }

    public async Task<IEnumerable<ImageForTableDto>> GetListOfUnusedImages()
    {
        string[] images = Directory.GetFiles(_imagePath).Select(filePath => Path.GetFileName(filePath)).ToArray();

        List<Image> dbImages = await _repository.Image.GetAllImages(false);

        List<ImageForTableDto> imageForTables= new();

        foreach (var image in images.Except(dbImages.Select(i => i.File)))       
        {
            imageForTables.Add(new ImageForTableDto(image, $"{_accessor?.HttpContext?.Request.Scheme}://{_accessor?.HttpContext?.Request.Host}{_accessor?.HttpContext?.Request.PathBase}/image/{image}"));
        }

        return imageForTables;
    }

    public async Task<CartDto> GetCart(int cartId) => _mapper.Map<CartDto>(await _repository.Cart.GetCartAsync(cartId, false));

    public async Task<CartDto> GetUserCart(int userId) => _mapper.Map<CartDto>(await _repository.Cart.GetUserCartAsync(userId, false) ?? throw new CartNotFound(userId));

    public async Task<CartDto> AddProductToCart(int productId, int cartId, int quantity, int? userId = null)
	{
        if (cartId == default)
        {
            Cart? dBcart = null;

            if(userId is not null)
				dBcart = await _repository.Cart.GetUserCartAsync((int)userId,true);

            if (dBcart == null)
            {
                Cart cartToCreate = new Cart { UserId = userId, Products = new List<ProductCart> { new ProductCart { ProductId = productId, Quantity = 1 } } };
                _repository.Cart.Create(cartToCreate);

				await _repository.SaveAsync();

				return _mapper.Map<CartDto>(cartToCreate);
			}

			dBcart.Products = new List<ProductCart> { new ProductCart { ProductId = productId, Quantity = 1 } };

			await _repository.SaveAsync();

			return _mapper.Map<CartDto>(dBcart);
		}

		Cart dbCart = await _repository.Cart.GetCartAsync(cartId, true) ?? throw new CartNotFound(cartId);

        if (dbCart.Products.Any(p => p.ProductId == productId))
        {
            dbCart.Products.First(p => p.ProductId == productId).Quantity += quantity;
        }
        else
        {
            dbCart.Products.Add(new ProductCart { ProductId = productId, Quantity = quantity });
		}

		await _repository.SaveAsync();

		return _mapper.Map<CartDto>(await _repository.Cart.GetCartAsync(dbCart.Id, false));
	}

	public async Task<CartDto> RemoveProductFromCart(int productId, int cartId)
	{
		Cart dbCart = await _repository.Cart.GetCartAsync(cartId, true) ?? throw new CartNotFound(cartId);

        dbCart.Products.Remove(dbCart.Products.First(p => p.ProductId == productId));

		await _repository.SaveAsync();

		return _mapper.Map<CartDto>(dbCart);
	}

    public async Task<CartDto> ClearCart(int cartId)
    {
        Cart dbCart = await _repository.Cart.GetCartAsync(cartId, true) ?? throw new CartNotFound(cartId);

        dbCart.Products.Clear();

        await _repository.SaveAsync();

        return _mapper.Map<CartDto>(dbCart);
    }

    public async Task<CartDto> JoinCartToUser(int cartId, int userId)
	{
        Cart cart = await _repository.Cart.GetCartAsync(cartId,true) ?? throw new CartNotFound(cartId);
        cart.UserId = userId;

        await _repository.SaveAsync();

		return _mapper.Map<CartDto>(cart);
	}

	public async Task<WishlistDto> AddRemoveFromWishlist(int wishlistId, int productId, int? userId = null)
	{
        if(wishlistId == default)
        {
            Product product = await _repository.Product.GetProductAsync(productId, true,true) ?? throw new ProductNotFound(productId);

			Wishlist wishlist = new Wishlist { UserId = userId };

			product.Wishlists.Add(wishlist);

			await _repository.SaveAsync();

            return _mapper.Map<WishlistDto>(wishlist);
		}

		Wishlist wishlistDb = await _repository.Wishlist.GetById(wishlistId, true);

		if (wishlistDb.Products.Any(w => w.Id == productId))
			wishlistDb.Products.Remove(wishlistDb.Products.First(w => w.Id == productId));

        else
			wishlistDb.Products.Add(await _repository.Product.GetProductAsync(productId, false, true) ?? throw new ProductNotFound(productId));

        await _repository.SaveAsync();

		return _mapper.Map<WishlistDto>(await _repository.Wishlist.GetById(wishlistId, false));
	}

	public async Task<WishlistDto> GetWishlist(int id) => _mapper.Map<WishlistDto>(await _repository.Wishlist.GetById(id, false));

    public async Task<WishlistDto> GetUserWishlist(int userId) => _mapper.Map<WishlistDto>(await _repository.Wishlist.GetUserWishList(userId, false));
    public async Task<WishlistDto> JoinWishlistToUser(int wishlistId, int userId)
	{
		Wishlist wishlist = await _repository.Wishlist.GetById(wishlistId, true);
		wishlist.UserId = userId;

		await _repository.SaveAsync();

		return _mapper.Map<WishlistDto>(wishlist);
	}

    public PagedList<ReviewDto> GetProductReviews(ReviewParameters reviewParameters) => _mapper.Map<PagedList<ReviewDto>>(_repository.Review.GetReviews(reviewParameters));

    public async Task SubmitReview(SubmitReviewDto submitReview)
    { 
        _repository.Review.Create(_mapper.Map<Review>(submitReview));
        await _repository.SaveAsync();
    }
}
