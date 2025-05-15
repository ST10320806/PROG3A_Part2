using PROG3A_Part2.Data;
using PROG3A_Part2.Models;
using Microsoft.EntityFrameworkCore;

namespace PROG3A_Part2.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) => _context = context;

        //Method for getting products added by a specific farmer
        public IEnumerable<Product> GetProductsByFarmerId(int farmerId)
            => _context.Products.Where(p => p.FarmerId == farmerId).ToList();

        //Method for the filering of products by category and date range
        public IEnumerable<Product> FilterProducts(string category, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.Products.Include(p => p.Farmer).AsQueryable();
            if (!string.IsNullOrEmpty(category)) query = query.Where(p => p.Category == category);
            if (startDate.HasValue) query = query.Where(p => p.ProductionDate >= startDate);
            if (endDate.HasValue) query = query.Where(p => p.ProductionDate <= endDate);
            return query.ToList();
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }

}
//Code corrected and debugged by ClaudeAi
//******************************************************************End Of File******************************************************************
