using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using flicket.Data;
using flicket.Models;
using flicket.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace flicket.Logic.FlightHandlers
{
    public class AddFlightHandler : IRequestHandler<AddFlightCommand>
    {
        private readonly DataContext _context;

        public AddFlightHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = new Flight
            {
                EconomyPrice = request.EconomyPrice,
                BusinessPrice = request.BusinessPrice,
                Departure = request.Departure,
                Arrival = request.Arrival,
                CompanyId = request.CompanyId
            };

            flight.Airline = await _context.Airlines.FirstAsync(x => x.Id == request.AirlineId);
            flight.From = await _context.Airports.FirstAsync(x => x.Id == request.AirportFromId);
            flight.To = await _context.Airports.FirstAsync(x => x.Id == request.AirportToId);

            await _context.Flights.AddAsync(flight);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
