using Microsoft.EntityFrameworkCore;
using PROG3A_Part2.Models;

namespace PROG3A_Part2.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            if (!context.Farmers.Any())//Adding the seed example data to the database
            {
                var farmer1 = new Farmer { Name = "John Doe", Email = "john@example.com", Password = "pass123" };
                var farmer2 = new Farmer { Name = "Jane Smith", Email = "jane@example.com", Password = "pass456" };

                var employee = new Employee { Name = "Admin", Email = "admin@example.com", Password = "adminpass" };//admin seed login

                context.Farmers.AddRange(farmer1, farmer2);
                context.Employees.Add(employee);

                context.Products.AddRange(
                    new Product { Name = "Carrots", Category = "Vegetable", ProductionDate = DateTime.Now.AddDays(-10), Farmer = farmer1 },
                    new Product { Name = "Apples", Category = "Fruit", ProductionDate = DateTime.Now.AddDays(-5), Farmer = farmer2 }
                );

                await context.SaveChangesAsync();
            }
        }
    }
}
//Code corrected and debugged by ClaudeAi
//******************************************************************End Of File******************************************************************
