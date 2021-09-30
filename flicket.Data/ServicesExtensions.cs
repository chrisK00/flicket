using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace flicket.Data
{
    public static class ServicesExtensions
    {
        public static void ConfigureDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString));

            services.AddIdentity<IdentityUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<DataContext>();
        }
    }
}
