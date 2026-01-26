using PROG3A_Part2.Models;

namespace PROG3A_Part2.Repository
{
    public interface IFarmerRepository
    {
        Farmer GetByCredentials(string email, string password);//Method to authenticate farmer credentials
        void Add(Farmer farmer);//Method for adding a farmer to the database
        IEnumerable<Farmer> GetAll();//Retrieving farmers from the database
    }
}
//******************************************************************End Of File******************************************************************
