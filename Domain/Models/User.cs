using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RefreshToken { get; set; }

        public virtual Wishlist Wishlist { get; set; } = new();
        public virtual Cart Cart { get; set; } = new();
		public DateTime RefreshTokenExpiryTime { get; set; }
    }
}