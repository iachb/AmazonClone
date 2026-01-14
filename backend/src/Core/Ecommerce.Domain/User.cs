using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Domain
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        // Skipping phone number, already included in IdentityUser base class
        public string? AvatarUrl { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
