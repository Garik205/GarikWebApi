// класс, унаследованный от Microsoft.EntityFrameworkCore.DbContext, для взаимодействия с базой данных через Entity Framework Core
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class ApplicationContext : DbContext // наследование от класса DbContext, чтобы взаимодействовать с базой данных
    {

        // Сущность Users предстовляет таблицу, в которой будут храниться объекты User
        // = null!(избежание ошибок), конструктор базового класса DbContext гарантирует, что данное свойство не будет хранить null
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        //public ApplicationContext()
        //{
                
        //}

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {
            //Database.EnsureCreated();
        } // конструктор для предачи дополнительных параметров в базовый класс DbContext

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    //Database.EnsureCreated();
        //    optionsBuilder.UseSqlite("Data Source=helloapp.db");
        //}
    }
}
