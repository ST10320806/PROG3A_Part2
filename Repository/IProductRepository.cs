using PROG3A_Part2.Models;

namespace PROG3A_Part2.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductsByFarmerId(int farmerId);//Method for getting products added by a specific farmer
        IEnumerable<Product> FilterProducts(string category, DateTime? productionDate);//Method for the filtering of products by category and date range
        void AddProduct(Product product);//Method for adding a new product to the database  
    }
}
//******************************************************************End Of File******************************************************************
