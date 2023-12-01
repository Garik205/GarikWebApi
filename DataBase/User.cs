// Главная сущность
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class User
    {
        public Guid id {  get; set; }
        [Required]
        public string firstName { get; set; } = null!;
        [Required]
        public string email { get; set; } = null!;
        [Required]
        public string password { get; set; } = null!; 
        public string gender { get; set; } = null!;
    }
}
