using Microsoft.EntityFrameworkCore;
using ShopApp.Models;

namespace ShopApp.Controllers.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new Category { Id = 1, Name = "Laptops and Desktops", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Monitors", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Printers and Scanners", DisplayOrder = 3 }

                );
        }
    }
}
