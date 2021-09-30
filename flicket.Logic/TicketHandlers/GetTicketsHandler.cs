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

namespace flicket.Logic.TicketHandlers
{
    public class GetTicketsHandler : IRequestHandler<GetTicketsQuery, IEnumerable<TicketListVM>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetTicketsHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TicketListVM>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Tickets.AsNoTracking();
            if (request.Params.CompanyId.HasValue)
            {
                query = query.Where(x => x.CompanyId == request.Params.CompanyId.Value);
            }

            return await query.ProjectTo<TicketListVM>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
