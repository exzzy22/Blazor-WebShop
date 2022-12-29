using Domain.Models;

namespace Shared.DataTransferObjects;

public record CartDto
{
	public int Id { get; init; }
	public int? UserId { get; init; }

	public virtual ICollection<ProductCartDto> Products { get; init; } = null!;
}
