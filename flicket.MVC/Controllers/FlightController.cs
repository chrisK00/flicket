﻿using System.Threading.Tasks;
using flicket.Models;
using flicket.Models.Params;
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

        /// <summary>
        /// this is the moment you see why simple razor pages are better :D
        /// </summary>
        /// <param name="flightParams"></param>
        /// <returns></returns>
        public async Task<IActionResult> IndexAsync([Bind(Prefix = "item2")] FlightParams flightParams)
        {
            var flights = await _mediator.Send(new GetFlightsQuery(flightParams));
            return View((flights, flightParams));
        }
    }
}
