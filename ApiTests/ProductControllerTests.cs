namespace ApiTests;

public class ProductControllerTests
{
    [Fact]
    public async Task AddProductTest()
    {
        // Arange
        var product = A.Dummy<ProductForCreationDto>();
        var serviceManager = A.Fake<IServiceManager>();
        var controller = new ProductController(serviceManager);

        // Act
        var result = await controller.AddProduct(product);
        var okResult = result as OkResult;

        // Assert
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);
    }

    [Fact]
    public async Task GetCarouselTopSellingTest()
    {
        // Arange
        var carousel = A.Dummy<CarouselDto>();
        var serviceManager = A.Fake<IServiceManager>();
        A.CallTo( () => serviceManager.ProductService.GetCarouselProductsAsync(x => (x.Sold))).Returns(Task.FromResult(carousel));
        var controller = new ProductController(serviceManager);

        // Act
        var result = await controller.GetCarouselTopSelling() as ActionResult;
        var okResult = result as OkObjectResult;
        var carouselReturn = okResult.Value as CarouselDto;

        // Assert
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);
        Assert.Equal(JsonSerializer.Serialize(carousel), JsonSerializer.Serialize(carouselReturn));
    }
}