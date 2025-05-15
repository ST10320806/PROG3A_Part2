using PROG3A_Part2.Models;

namespace PROG3A_Part2.Repository
{
    public interface IEmployeeRepository
    {
        Employee GetByCredentials(string email, string password);
    }
}
//******************************************************************End Of File******************************************************************
