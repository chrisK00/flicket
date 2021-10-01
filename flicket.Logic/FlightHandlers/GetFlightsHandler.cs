using System;
using System.Collections.Generic;
using System.Linq;
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
    public class GetFlightsHandler : IRequestHandler<GetFlightsQuery, IEnumerable<FlightListVM>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetFlightsHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FlightListVM>> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Flights.AsNoTracking();

            query = query
                .Where(f =>
                 f.Departure >= request.Params.Departure
                 && f.Arrival <= request.Params.Arrival
                 && !f.Cancelled
                 && _context.Tickets.Where(t => t.FlightId == f.Id).Count() >= request.Params.Passengers);

            if (request.Params.CompanyId.HasValue)
            {
                query = query.Where(x => x.CompanyId == request.Params.CompanyId.Value);
            }

            return await query.ProjectTo<FlightListVM>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}