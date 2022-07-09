using Lesson28.EF.DataAccess.Entities;
using Lesson28.EF.DataAccess.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Lesson28.EF.DataAccess
{
    public class ShopDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server=.;Database=ShopDB;Trusted_Connection=True;
            optionsBuilder.UseSqlServer(@"Server=10.37.129.2;Database=ShopDB;User Id=SA;Password=Qwerty_1_qwertY;");
        }
    }
}