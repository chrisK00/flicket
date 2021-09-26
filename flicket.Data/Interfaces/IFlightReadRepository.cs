using System.Collections.Generic;
using System.Threading.Tasks;
using flicket.Models.ViewModels;

namespace flicket.Data.Interfaces
{
    public interface IFlightReadRepository
    {
        Task<FlightDetailVM> GetForDetailAsync(int id);
        Task<IEnumerable<FlightListVM>> GetAllForListAsync();
    }
}
