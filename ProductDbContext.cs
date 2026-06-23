using Microsoft.EntityFrameworkCore;

namespace ProductDatabaseApi
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
    }
}