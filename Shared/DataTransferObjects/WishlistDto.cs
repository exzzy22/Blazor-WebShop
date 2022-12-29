using Domain.Models;

namespace Shared.DataTransferObjects;

public record WishlistDto
{
	public int Id { get; init; }
	public int? UserId { get; init; }

	public virtual ICollection<ProductCart> Products { get; init; } = null!;
}
