using PROG3A_Part2.Models;

namespace PROG3A_Part2.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductsByFarmerId(int farmerId);
        IEnumerable<Product> FilterProducts(string category, DateTime? productionDate);
        void AddProduct(Product product);
    }
}
//******************************************************************End Of File******************************************************************
