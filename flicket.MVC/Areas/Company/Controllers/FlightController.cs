using System;
using System.Linq;
using System.Threading.Tasks;
using flicket.Constants;
using flicket.Models;
using flicket.Models.Params;
using flicket.Models.ViewModels;
using flicket.MVC.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace flicket.MVC.Areas.Company.Controllers
{
    [Area(nameof(Company))]
    [Authorize(Roles = Role.Admin + "," + Role.Company)]
    public class FlightController : Controller
    {
        private readonly IMediator _mediator;

        public FlightController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var flightVM = new AddFlightVM();
            await BuildAddFlightVMAsync(flightVM);
            return View(flightVM);
        }

        private async Task BuildAddFlightVMAsync(AddFlightVM flightVM)
        {
            var airports = await _mediator.Send(new GetAirportsQuery());
            var airlines = await _mediator.Send(new GetAirlinesQuery());

            flightVM.Airports = airports.Select(x => new SelectListItem
            {
                Text = $"{x.Location}({x.Name})",
                Value = x.Id.ToString()
            });

            flightVM.Airlines = airlines.Select(x => new SelectListItem
            {
                Text = $"{x.Name})",
                Value = x.Id.ToString()
            });
        }

        [ValidateAntiForgeryToken]
        [ActionName(nameof(Create))]
        [HttpPost]
        public async Task<IActionResult> CreatePost(AddFlightVM flightVM)
        {
            if (!ModelState.IsValid)
            {
                await BuildAddFlightVMAsync(flightVM);
                return View(flightVM);
            }

            var flightCommand = new AddFlightCommand(flightVM.AirportFromId, flightVM.AirportToId, flightVM.AirlineId, flightVM.BusinessPrice,
                flightVM.EconomyPrice, flightVM.Departure.ToUniversalTime(), flightVM.Arrival.ToUniversalTime(), User.GetCompanyId().Value);

            await _mediator.Send(flightCommand);
            return RedirectToAction(nameof(Index));
        }

        #region API endpoints

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var flightParams = new FlightParams
            {
                Passengers = 0,
                CompanyId = User.GetCompanyId(),
                Arrival = DateTime.MaxValue,
                Departure = DateTime.MinValue
            };

            var flights = await _mediator.Send(new GetFlightsQuery(flightParams));
            return Ok(new { data = flights });
        }

        #endregion
    }
}
