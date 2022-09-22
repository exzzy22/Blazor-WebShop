using FakeItEasy.Sdk;

namespace ApiTests;

public class ProductControllerTests
{
    //[Fact]
    //public async Task AddProductTest()
    //{
    //    // Arange
    //    var aa = new ProductDto { Attributes = new CpuAtrributesDto() };
    //    //var product = new Fake(aa);

    //    //var product = A.Fake<ProductDto>(x => x.ConfigureFake(p => p.Attributes = new CpuAtrributesDto()));
    //    var serviceManager = A.Fake<IServiceManager>();
    //    var controller = new ProductController(serviceManager);

    //    // Act
    //    var result = await controller.AddProduct(aa);
    //    var okResult = result as OkResult;

    //    // Assert
    //    Assert.NotNull(okResult);
    //    Assert.Equal(200, okResult.StatusCode);
    //}

    //[Fact]
    //public async Task GetCarouselTopSellingTest()
    //{
    //    // Arange
    //    int numberOfCategories = 4;
    //    int numberOfProducts = 8;
    //    //var carousel = new CarouselDto(A.CollectionOfFake<CategoryDto>(numberOfCategories), A.CollectionOfFake<ProductCarouselDto>(numberOfProducts));
    //    var carousel = A.Fake<CarouselDto>(c => c.WithArgumentsForConstructor(
    //        () => new CarouselDto(A.CollectionOfFake<CategoryDto>(numberOfCategories).AsEnumerable(), A.CollectionOfFake<ProductCarouselDto>(numberOfProducts).AsEnumerable())));
    //    var serviceManager = A.Fake<IServiceManager>();
    //    A.CallTo( () => serviceManager.ProductService.GetCarouselProductsAsync(x => (x.Sold), numberOfCategories, numberOfProducts)).Returns(Task.FromResult(carousel));
    //    var controller = new ProductController(serviceManager);

    //    // Act
    //    var result = await controller.GetCarouselTopSelling(numberOfCategories, numberOfProducts) as ActionResult;
    //    var okResult = result as OkObjectResult;
    //    var carouselReturn = okResult.Value as CarouselDto;

    //    // Assert
    //    Assert.NotNull(okResult);
    //    Assert.Equal(200, okResult.StatusCode);
    //    Assert.NotNull(carouselReturn);
    //    Assert.Equal(carouselReturn.Categories.Count(), numberOfCategories);
    //    Assert.Equal(carouselReturn.Products.Count(), numberOfProducts);

    //}
}