// Зависимая сущность
using System;
using System.ComponentModel.DataAnnotations;


namespace DataBase
{
    public class Order
    {
        public Guid OrderId { get; set; } // Номер заказа

        [Required]
        public string infoOrder { get; set; } = null!; // Информация о заказе

        //public int UserId { get; set; } // внешний ключ
        public User? User { get; set; } // навигацонное свойство
    }
}
