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

namespace flicket.Logic.AirlineHandlers
{
    public class GetAirlinesHandler : IRequestHandler<GetAirlinesQuery, IEnumerable<AirlineVM>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetAirlinesHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AirlineVM>> Handle(GetAirlinesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Airlines.ProjectTo<AirlineVM>(_mapper.ConfigurationProvider)
                .AsNoTracking().ToListAsync();
        }
    }
}
