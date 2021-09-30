using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace flicket.Models.Entities
{
    public class AppUser : IdentityUser
    {
        [NotMapped]
        public string Role { get; set; }
        public int? CompanyId { get; set; }
    }
}
