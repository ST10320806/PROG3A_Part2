using PROG3A_Part2.Data;
using PROG3A_Part2.Models;

namespace PROG3A_Part2.Repository
{
    public class EmployeeRepository : IEmployeeRepository//implements the interface
    {
        private readonly AppDbContext _context;//store database context instance
        public EmployeeRepository(AppDbContext context) => _context = context;//Deoenpendency injection of the database context 

        public Employee GetByCredentials(string email, string password)//Authenticating employee credentials
            => _context.Employees.FirstOrDefault(e => e.Email == email && e.Password == password);//Gets first matching employee if credentials are valid
    }
}
//Code corrected and debugged by ClaudeAi
//******************************************************************End Of File******************************************************************
