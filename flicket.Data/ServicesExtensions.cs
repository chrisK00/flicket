using flicket.Data.Interfaces;
using flicket.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace flicket.Data
{
    public static class ServicesExtensions
    {
        public static void ConfigureDataServices(this IServiceCollection services)
        {
            services.AddScoped<IFlightWriteRepository, FlightWriteRepository>();
            services.AddScoped<IFlightReadRepository, FlightReadRepository>();
        }
    }
}
