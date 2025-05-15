using PROG3A_Part2.Models;

namespace PROG3A_Part2.Repository
{
    public interface IFarmerRepository
    {
        Farmer GetByCredentials(string email, string password);
        void Add(Farmer farmer);
        IEnumerable<Farmer> GetAll();
    }
}
//******************************************************************End Of File******************************************************************
