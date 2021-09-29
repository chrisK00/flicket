using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using flicket.Data;
using flicket.Models;
using flicket.Models.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace flicket.Logic.TicketHandlers
{
    public class GetAirportsHandler : IRequestHandler<GetAirportsQuery, IEnumerable<AirportVM>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetAirportsHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AirportVM>> Handle(GetAirportsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Airports.ProjectTo<AirportVM>(_mapper.ConfigurationProvider)
                .AsNoTracking().ToListAsync();
        }
    }
}
