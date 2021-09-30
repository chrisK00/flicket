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
            return string.IsNullOrWhiteSpace(value) ? null : int.Parse(value);
        }
    }
}
