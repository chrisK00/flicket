using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using flicket.Data;
using flicket.Models;
using flicket.Models.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace flicket.Logic.FlightHandlers
{
    public class GetFlightHandler : IRequestHandler<GetFlightQuery, FlightDetailVM>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetFlightHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FlightDetailVM> Handle(GetFlightQuery request, CancellationToken cancellationToken)
        {
            return await _context.Flights.ProjectTo<FlightDetailVM>(_mapper.ConfigurationProvider)
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
        }
    }
}
