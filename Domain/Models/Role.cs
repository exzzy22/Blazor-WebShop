using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class Role : IdentityRole<int>
    {
        public override string Name { get; set; } = null!;
    }
}