namespace Shared.DataTransferObjects;

public record ProductCartDto
{
	public int Id { get; init; }
	public int ProductId { get; init; }
	public int Quantity { get; init; } = 1;

	public virtual ProductDto Product { get; init; } = null!;
}
