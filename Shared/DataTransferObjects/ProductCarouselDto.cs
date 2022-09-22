﻿namespace Shared.DataTransferObjects;

public record ProductCarouselDto
{
    public string Name { get; init; } = null!;
    public int Discount { get; init; } = 0;
    public int InStock { get; init; } = 0;
    public int Sold { get; init; } = 0;
    public int CategoryId { get; init; }

    public virtual ICollection<PriceDto> Prices { get; init; } = null!;
}
