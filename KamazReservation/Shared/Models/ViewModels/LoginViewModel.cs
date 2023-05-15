using System.ComponentModel.DataAnnotations;

namespace KamazReservation.Shared.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Введите ваш логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Введите ваш пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
