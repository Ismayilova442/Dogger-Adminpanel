using Microsoft.EntityFrameworkCore;
using WebApplication43.Models;

namespace WebApplication43.Data
{
    public class DoggerDBContext : DbContext
    {
        public DoggerDBContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
