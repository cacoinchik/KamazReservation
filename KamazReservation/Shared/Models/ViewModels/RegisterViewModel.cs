using System.ComponentModel.DataAnnotations;

namespace KamazReservation.Shared.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите ваше имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите вашу фамилию")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите ваш логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
