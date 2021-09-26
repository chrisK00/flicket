using System.Collections.Generic;
using flicket.Models.ViewModels;
using MediatR;

namespace flicket.Models
{
    public record GetFlightDetailQuery(int Id) : IRequest<FlightDetailVM>;
    public record GetFlightsListQuery() : IRequest<IEnumerable<FlightListVM>>;
}
