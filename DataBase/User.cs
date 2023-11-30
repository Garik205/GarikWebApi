// Объекты, которые будут храниться в базе данных
namespace DataBase
{
    public class User
    {
        public Guid id {  get; set; }
        public string? firstName { get; set; } = null!; 
        public string? email { get; set; } = null!;
        public string? password { get; set; } = null!; 
        public string? gender { get; set; } = null!;
    }
}
