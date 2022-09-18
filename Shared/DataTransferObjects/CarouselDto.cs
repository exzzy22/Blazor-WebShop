namespace Shared.DataTransferObjects;

public record CarouselDto(IEnumerable<CategoryDto> Categories, IEnumerable<ProductForCreationDto> Products);
