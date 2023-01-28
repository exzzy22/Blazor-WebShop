namespace Shared.DataTransferObjects;

public record AddressDto
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Street { get; init; } = null!;
    public string City { get; init; } = null!;
    public string Country { get; init; } = null!;
    public string ZipCode { get; init; } = null!;
    public string Tel { get; init; } = null!;
}
