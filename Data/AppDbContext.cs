using Microsoft.EntityFrameworkCore;
using PROG3A_Part2.Models;

namespace PROG3A_Part2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       public DbSet<Farmer> Farmers  { get; set; }

       public DbSet<Employee> Employees { get; set; }
       public DbSet<Product> Products { get; set; }
    }
}
