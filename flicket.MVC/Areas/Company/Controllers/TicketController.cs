using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using flicket.Models;
using flicket.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace flicket.MVC.Areas.Company.Controllers
{
    [Area(nameof(Company))]
    public class TicketController : Controller
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateAsync()
        {
            var flights = await _mediator.Send(new GetFlightsListQuery());
            var ticketVM = new AddTicketVM
            {
                Flights = new SelectList(flights)
            };

            return View();
        }

        [ValidateAntiForgeryToken]
        [ActionName(nameof(CreateAsync))]
        public IActionResult CreatePost(AddTicketVM ticketVM)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
