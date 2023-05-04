using Microsoft.AspNetCore.Identity;

namespace KamazReservation.Shared.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? CarBrand { get; set; }
        public string? CarModel { get; set; }
        public string? CarNumber { get; set; }
    }
}
