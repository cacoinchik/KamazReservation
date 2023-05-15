using System.ComponentModel.DataAnnotations;

namespace KamazReservation.Shared.Models.ViewModels
{
    public class BookingViewModel
    {
        [Required]
        public int PlaceNumber { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите ваше имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите вашу фамилию")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите бренд вашего автомобиля")]
        public string CarBrand { get; set; }

        [Required(ErrorMessage = "Введите модель вашего автомобиля")]
        public string CarModel { get; set; }

        [Required(ErrorMessage = "Введите номер вашего автомобиля")]
        public string CarNumber { get; set; }

        [Required(ErrorMessage = "Укажите дату и время начала бронирования")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Укажите дату и время конца бронирования")]
        public DateTime EndTime { get; set; }
    }
}
