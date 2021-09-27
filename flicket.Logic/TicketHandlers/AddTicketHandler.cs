using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using flicket.Data;
using flicket.Models;
using flicket.Models.Entities;
using MediatR;

namespace flicket.Logic.TicketHandlers
{
    public class AddTicketHandler : IRequestHandler<AddTicketCommand>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AddTicketHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = new Ticket
            {
                FlightId = request.FlightId,
                Seat = new Seat { Position = request.Position, SeatClass = request.SeatClass }
            };

            ticket.Price = request.SeatClass == SeatClass.Business
                ? _context.Flights.FirstOrDefault(x => x.Id == request.FlightId).BusinessPrice
                : _context.Flights.FirstOrDefault(x => x.Id == request.FlightId).EconomyPrice;
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
