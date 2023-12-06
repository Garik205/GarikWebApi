// Зависимая сущность
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataBase
{
    public class Order
    {
        public Guid OrderId { get; set; } // Номер заказа
        
        [Required(ErrorMessage ="Укажите информацию о заказе!")]
        public string infoOrder { get; set; } = null!; // Информация о заказе

        [ForeignKey("User")] // Явное указание, что это внешний ключ
        public Guid UserId { get; set; } // внешний ключ
        //public User? User { get; set; } // навигацонное свойство
    }
}
