using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using flicket.Data.Interfaces;
using flicket.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace flicket.Data.Repositories
{
    internal class FlightReadRepository : IFlightReadRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FlightReadRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FlightListVM>> GetAllForListAsync()
        {
            return await _context.Flights.ProjectTo<FlightListVM>(_mapper.ConfigurationProvider)
                .AsNoTracking().ToListAsync();
        }

        public async Task<FlightDetailVM> GetForDetailAsync(int id)
        {
            return await _context.Flights.ProjectTo<FlightDetailVM>(_mapper.ConfigurationProvider)
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
