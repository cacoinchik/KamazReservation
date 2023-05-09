using System.ComponentModel.DataAnnotations;

namespace KamazReservation.Shared.Models.ViewModels
{
    public class BookingViewModel
    {
        [Required]
        [Display(Name = "№ Парковочного места")]
        public int PlaceNumber { get; set; }

        [Required]
        [Display(Name = "Ваше имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Ваша фамилия")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Марка автомобиля")]
        public string CarBrand { get; set; }

        [Required]
        [Display(Name = "Модель автомобиля")]
        public string CarModel { get; set; }

        [Required]
        [Display(Name = "Номер автомобиля")]
        public string CarNumber { get; set; }

        [Required]
        [Display(Name = "Дата и время начала")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "Дата и время начала")]
        public DateTime EndTime { get; set; }
    }
}
