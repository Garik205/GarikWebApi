using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataBase.Models
{
    public class AddOrderForUser
    {
        [Required(ErrorMessage = "Укажите данные по заказу!")]
        public string infoOrder { get; set; } = null!;

        [ForeignKey("User")]
        public Guid UserId { get; set; } // Внешний ключ
    }
}
