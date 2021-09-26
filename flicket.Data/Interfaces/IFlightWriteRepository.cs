using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flicket.Models.Entities;

namespace flicket.Data.Interfaces
{
    public interface IFlightWriteRepository
    {
        Task<Flight> GetAsync(int id);
        Task AddAsync(Flight flight);
        void Delete(Flight flight);
    }
}
