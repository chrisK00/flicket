using System.Collections.Generic;
using flicket.Models.Params;
using flicket.Models.ViewModels;
using MediatR;

namespace flicket.Models
{
    public record GetFlightQuery(int Id) : IRequest<FlightDetailVM>;
    public record GetFlightsQuery(FlightParams Params) : IRequest<IEnumerable<FlightListVM>>;
    public record GetTicketsQuery(TicketParams Params) : IRequest<IEnumerable<TicketListVM>>;
    public record GetAirlinesQuery() : IRequest<IEnumerable<AirlineVM>>;
    public record GetAirportsQuery() : IRequest<IEnumerable<AirportVM>>;
}
