using CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace Plugins.DataSore.SQL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.categoryId);

            // seeding primary data
            modelBuilder.Entity<Category>().HasData(
                new Category { categoryId = 1, Name = "Beverage", Description = "Beverage" },
                new Category { categoryId = 2, Name = "Bakery", Description = "Bakery" },
                new Category { categoryId = 3, Name = "Meat", Description = "Meat" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductId = 1, categoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99 },
                new Product() { ProductId = 2, categoryId = 1, Name = "Canada Dry", Quantity = 200, Price = 1.99 },
                new Product() { ProductId = 3, categoryId = 2, Name = "Whole Wheat Bread", Quantity = 300, Price = 1.50 },
                new Product() { ProductId = 4, categoryId = 2, Name = "White Bread", Quantity = 300, Price = 1.50 }
            );
        }

    }
}