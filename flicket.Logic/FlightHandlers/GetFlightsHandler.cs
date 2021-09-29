﻿using System.Collections.Generic;
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
            return await _context.Flights.ProjectTo<FlightListVM>(_mapper.ConfigurationProvider)
                .AsNoTracking().ToListAsync();
        }
    }
}