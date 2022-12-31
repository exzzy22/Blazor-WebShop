using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RefreshToken { get; set; }
		public string? Address { get; set; }
		public string? City { get; set; }
		public string? Country { get; set; }
		public string? ZipCode { get; set; }
		public string? Tel { get; set; }

		public virtual Wishlist Wishlist { get; set; } = null!;
		public virtual Cart Cart { get; set; } = null!;
		public DateTime RefreshTokenExpiryTime { get; set; }
    }
}