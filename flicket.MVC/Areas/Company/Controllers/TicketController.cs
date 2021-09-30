using System.Linq;
using System.Threading.Tasks;
using flicket.Constants;
using flicket.Models;
using flicket.Models.Params;
using flicket.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace flicket.MVC.Areas.Company.Controllers
{
    [Area(nameof(Company))]
    [Authorize(Roles = Role.Admin + "," + Role.Company)]
    public class TicketController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IHtmlHelper _htmlHelper;

        public TicketController(IMediator mediator, IHtmlHelper htmlHelper)
        {
            _mediator = mediator;
            _htmlHelper = htmlHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var ticketVM = new AddTicketVM();
            await BuildAddTicketVMAsync(ticketVM);

            return View(ticketVM);
        }

        private async Task BuildAddTicketVMAsync(AddTicketVM ticketVM)
        {
            var flights = await _mediator.Send(new GetFlightsQuery(new FlightParams { Passengers = 0 }));
            ticketVM.Flights = flights.Select(x => new SelectListItem
            {
                Text = $"{x.From.Name}-{x.To.Name}: {x.Departure}",
                Value = x.Id.ToString()
            });

            ticketVM.SeatClasses = _htmlHelper.GetEnumSelectList<SeatClass>();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Create))]
        public async Task<IActionResult> CreatePost(AddTicketVM ticketVM)
        {
            if (!ModelState.IsValid)
            {
                await BuildAddTicketVMAsync(ticketVM);

                return View(ticketVM);
            }

            await _mediator.Send(new AddTicketCommand(ticketVM.FlightId, ticketVM.SeatClass, ticketVM.Position));
            return RedirectToAction(nameof(Index));
        }

        #region API endpoints

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tickets = await _mediator.Send(new GetTicketsQuery());
            return Ok(new { data = tickets });
        }

        #endregion
    }
}
