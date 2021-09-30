using System;
using MediatR;

namespace flicket.Models
{
    public record AddTicketCommand(int FlightId, SeatClass SeatClass, string Position, int CompanyId) : IRequest;
    public record AddFlightCommand(int AirportFromId, int AirportToId, int AirlineId, double BusinessPrice, double EconomyPrice,
        DateTime Departure, DateTime Arrival, int CompanyId) : IRequest;
}
