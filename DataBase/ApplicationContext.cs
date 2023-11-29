﻿// класс, унаследованный от Microsoft.EntityFrameworkCore.DbContext, для взаимодействия с базой данных через Entity Framework Core
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataBase
{
    public class ApplicationContext : DbContext // наследование от класса DbContext, чтобы взаимодействовать с базой данных
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {
            Database.EnsureCreated(); 
        } // конструктор для предачи дополнительных параметров в базовый класс DbContext

        // квойство Users предстовляет таблицу, в которой будут храниться объекты User
        // = null!(избежание ошибок), конструктор базового класса DbContext гарантирует, что данное свойство не будет хранить null
        public DbSet<User> Users { get; set; } = null!;
    }
}
