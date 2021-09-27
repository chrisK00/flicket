using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace flicket.Models
{
    public record AddTicketCommand(int FlightId, SeatClass SeatClass, string Position) : IRequest;
}
