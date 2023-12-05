
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
    public class AddUserModel
    {
        [Required(ErrorMessage = "Укажите ваше имя!")]
        public string firstName { get; set; } = null!;
        [Required(ErrorMessage = "Укажите ваш адрес электронной почты!")]
        public string email { get; set; } = null!;
        [Required(ErrorMessage = "Укажите пароль!")]
        public string password { get; set; } = null!;
        public string gender { get; set; } = null!;
    }
}
