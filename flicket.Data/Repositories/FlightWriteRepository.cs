using System.Threading.Tasks;
using flicket.Data.Interfaces;
using flicket.Models.Entities;

namespace flicket.Data.Repositories
{

    internal class FlightWriteRepository : IFlightWriteRepository
    {
        private readonly DataContext _context;

        public FlightWriteRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Flight flight)
        {
            await _context.Flights.AddAsync(flight);
        }

        public void Delete(Flight flight)
        {
            _context.Flights.Remove(flight);
        }

        public async Task<Flight> GetAsync(int id)
        {
            return await _context.Flights.FindAsync(id);
        }
    }
}
