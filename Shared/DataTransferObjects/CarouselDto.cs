namespace Shared.DataTransferObjects;

public record CarouselDto(CategoryDto Category, IEnumerable<ProductDto> Products);
