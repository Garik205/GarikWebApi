// Объекты, которые будут храниться в базе данных
namespace DataBase
{
    public class User
    {
        public int id {  get; set; }
        public string firstName { get; set; } = null!; 
        public string email { get; set; } = null!;
        public string password { get; set; } = null!; 
    }
}
