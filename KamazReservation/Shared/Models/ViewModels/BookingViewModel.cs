using System.ComponentModel.DataAnnotations;

namespace KamazReservation.Shared.Models.ViewModels
{
    public class BookingViewModel
    {
        [Required]
        public int PlaceNumber { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string CarBrand { get; set; }

        [Required]
        public string CarModel { get; set; }

        [Required]
        public string CarNumber { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
    }
}
