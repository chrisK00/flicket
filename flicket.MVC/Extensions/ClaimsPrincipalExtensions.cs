using System.Linq;
using System.Security.Claims;
using flicket.Models.ViewModels;

namespace flicket.MVC.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int? GetCompanyId(this ClaimsPrincipal user)
        {
           var value = user.Claims.FirstOrDefault(x => x.Type == nameof(AppUserVM.CompanyId))?.Value;
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return int.Parse(value);
        }
    }
}
