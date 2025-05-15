using PROG3A_Part2.Data;
using PROG3A_Part2.Models;

namespace PROG3A_Part2.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context) => _context = context;

        public Employee GetByCredentials(string email, string password)
            => _context.Employees.FirstOrDefault(e => e.Email == email && e.Password == password);
    }
}
//Code corrected and debugged by ClaudeAi
//******************************************************************End Of File******************************************************************
