using flicket.Logic.FlightHandlers;
using flicket.Logic.Profiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace flicket.Logic.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureLogicServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(FlightProfile).Assembly);
            services.AddMediatR(typeof(GetFlightHandler).Assembly);
        }
    }
}
