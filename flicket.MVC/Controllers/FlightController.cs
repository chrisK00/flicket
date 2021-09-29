using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flicket.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace flicket.MVC.Controllers
{
    public class FlightController : Controller
    {
        private readonly IMediator _mediator;

        public FlightController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var flights = await _mediator.Send(new GetFlightsQuery());
            return View(flights);
        }
    }
}
