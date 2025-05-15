using PROG3A_Part2.Models;

namespace PROG3A_Part2.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductsByFarmerId(int farmerId);
        IEnumerable<Product> FilterProducts(string category, DateTime? startDate, DateTime? endDate);
        void AddProduct(Product product);
    }
}
//******************************************************************End Of File******************************************************************
