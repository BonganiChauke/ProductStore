using Microsoft.EntityFrameworkCore;
using ProductStore.Models;

namespace ProductStore.Services
{
    // inherenting from DBContext
    public class ApplicationDbContext : DbContext
    {
        //contrustor class
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        //models declarations
        public DbSet<Product> Products { get; set; }
    }
}
