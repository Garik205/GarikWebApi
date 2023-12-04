// Главная сущность
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace DataBase
{
    public class User
    {
        //public Guid UserId = Guid.NewGuid();
        public Guid id { get { return Guid.NewGuid(); } set { } }
        [Required]
        public string firstName { get; set; } = null!;
        [Required]
        public string email { get; set; } = null!;
        [Required]
        public string password { get; set; } = null!; 
        public string gender { get; set; } = null!;
    }
}
