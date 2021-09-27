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
    public class GetTicketsListHandler : IRequestHandler<GetTicketsListQuery, IEnumerable<TicketListVM>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetTicketsListHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TicketListVM>> Handle(GetTicketsListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tickets.ProjectTo<TicketListVM>(_mapper.ConfigurationProvider)
                .AsNoTracking().ToListAsync();
        }
    }
}
