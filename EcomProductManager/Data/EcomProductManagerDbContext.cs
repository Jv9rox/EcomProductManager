using EcomProductManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EcomProductManager.Data
{
    public class EcomProductManagerDbContext:DbContext
    {
        public EcomProductManagerDbContext(DbContextOptions<EcomProductManagerDbContext> options) : base(options) { }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}
