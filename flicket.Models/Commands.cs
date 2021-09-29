using System;
using MediatR;

namespace flicket.Models
{
    public record AddTicketCommand(int FlightId, SeatClass SeatClass, string Position) : IRequest;
    public record AddFlightCommand(DateTime Departure, DateTime Arrival) : IRequest;
}
