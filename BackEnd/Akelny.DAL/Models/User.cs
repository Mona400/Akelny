using Microsoft.AspNetCore.Identity;

namespace Akelny.DAL.Models
{
    public enum Gender
    {
        male,
        female,
    }

    public class User : IdentityUser
    {

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool IsEmailVerified { get; set; }
        public string UserType { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public string? Address { get; set; } = string.Empty;

        public string? ProfileImg { get; set; } = string.Empty;
        public ICollection<Subscriptions>? subscriptions { get; set; }

        public ICollection<Review>? Reviews { get; set; }
    }
}
