using System.ComponentModel.DataAnnotations;

namespace KamazReservation.Shared.Models.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        public string? CarBrand { get; set; }

        public string? CarModel { get; set; }

        public string? CarNumber { get; set; }
    }
}
