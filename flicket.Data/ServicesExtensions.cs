using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace flicket.Data
{
    public static class ServicesExtensions
    {
        public static void ConfigureDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
