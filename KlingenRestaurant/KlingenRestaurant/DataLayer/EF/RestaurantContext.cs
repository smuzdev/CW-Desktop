using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace KlingenRestaurant
{
    public class RestaurantContext : DbContext
    {
        // Имя будущей базы данных можно указать через
        // вызов конструктора базового класса
        public RestaurantContext() : base("KlingenRestaurant")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // Отражение таблиц базы данных на свойства с типом DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<MenuDish> Dishes { get; set; }
        public DbSet<NewsBlock> News { get; set; }
        public DbSet<Reservation> Reservations { get; set; } 
        public DbSet<Table> Tables { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}

