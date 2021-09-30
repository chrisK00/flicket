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
    public class AddFlightHandler : IRequestHandler<AddTicketCommand>
    {
        private readonly DataContext _context;

        public AddFlightHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = new Ticket
            {
                FlightId = request.FlightId,
                Seat = new Seat { Position = request.Position, SeatClass = request.SeatClass },
                CompanyId = request.CompanyId
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
