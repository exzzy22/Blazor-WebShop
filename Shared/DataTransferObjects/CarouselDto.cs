namespace Shared.DataTransferObjects;

public record CarouselDto(IEnumerable<ProductDto> Products, IEnumerable<string> Categories);
