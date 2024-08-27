using Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Core.Repo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShippingAddress> ShippingAddress { get; set; }
    }
}
