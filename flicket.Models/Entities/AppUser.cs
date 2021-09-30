using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace flicket.Models.Entities
{
    public class AppUser : IdentityUser
    {
        [NotMapped]
        public string Role { get; set; }
        public int? CompanyId { get; set; }
    }
}
