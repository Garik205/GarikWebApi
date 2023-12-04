// Зависимая сущность
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataBase
{
    public class Order
    {
        //public Guid IdOrder = Guid.NewGuid();
        public Guid OrderId { get { return Guid.NewGuid(); } set { } } // Номер заказа
        
        [Required]
        public string infoOrder { get; set; } = null!; // Информация о заказе

        [ForeignKey("User")] // Явное указание, что это внешний ключ
        public Guid UserId { get; set; } // внешний ключ
        //public User? User { get; set; } // навигацонное свойство
    }
}
