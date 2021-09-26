using flicket.Data.Interfaces;
using flicket.Data.Repositories;
using flicket.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace flicket.Data
{
    public static class ServicesExtensions
    {
        public static void ConfigureDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IFlightWriteRepository, FlightWriteRepository>();
            services.AddScoped<IFlightReadRepository, FlightReadRepository>();

            services.AddAutoMapper(typeof(FlightProfiles).Assembly);

            services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
