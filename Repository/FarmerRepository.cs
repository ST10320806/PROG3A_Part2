using PROG3A_Part2.Data;
using PROG3A_Part2.Models;

namespace PROG3A_Part2.Repository
{
    public class FarmerRepository : IFarmerRepository
    {
        private readonly AppDbContext _context;
        public FarmerRepository(AppDbContext context) => _context = context;

        public Farmer GetByCredentials(string email, string password)
            => _context.Farmers.FirstOrDefault(f => f.Email == email && f.Password == password);

        public void Add(Farmer farmer)//Method for adding a farmer to the database
        {
            _context.Farmers.Add(farmer);
            _context.SaveChanges();
        }

        public IEnumerable<Farmer> GetAll() => _context.Farmers.ToList();
    }
}
//Code corrected and debugged by ClaudeAi
//******************************************************************End Of File******************************************************************

