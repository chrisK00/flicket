using System;
using flicket.Models.Params;
using FluentValidation;

namespace flicket.MVC.Validators
{
    public class FlightParamsValidator : AbstractValidator<FlightParams>
    {
        public FlightParamsValidator()
        {
            RuleFor(x => x.Departure).GreaterThan(DateTime.UtcNow.AddDays(-1));
            RuleFor(x => x.Arrival).GreaterThan(x => x.Departure);
            RuleFor(x => x.Passengers).GreaterThanOrEqualTo(1).LessThanOrEqualTo(8);
        }
    }
}
