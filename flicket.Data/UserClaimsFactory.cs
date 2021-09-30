using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace flicket.Data
{
    public class UserClaimsFactory : UserClaimsPrincipalFactory<IdentityUser, IdentityRole>
    {
        private readonly DataContext _context;

        public UserClaimsFactory(DataContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {
            _context = context;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            var userId = identity.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var appUser = await _context.AppUsers.FindAsync(userId);

            if (appUser == null || !appUser.CompanyId.HasValue)
            {
                return identity;
            }

            var claim = new Claim(nameof(appUser.CompanyId), appUser.CompanyId.Value.ToString());
            identity.AddClaim(claim);
            return identity;
        }
    }
}
