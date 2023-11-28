// класс, унаследованный от Microsoft.EntityFrameworkCore.DbContext, для взаимодействия с базой данных через Entity Framework Core
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class ApplicationContext : DbContext // наследование от класса DbContext, чтобы взаимодействовать с базой данных
    {
        // квойство Users предстовляет таблицу, в которой будут храниться объекты User
        // = null!(избежание ошибок), конструктор базового класса DbContext гарантирует, что данное свойство не будет хранить null
        public DbSet<User> Users { get; set; } = null!;
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) // Конструктор для предачи натсройки контекста данных 
        {
            Database.EnsureCreated();  // Создание бд происходит точно, так как её создание указано явно
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DBuser.db"); // передаётся строка подключения, в которой есть параметр Data Source(указывает на имя бд)
        }
    }
}
