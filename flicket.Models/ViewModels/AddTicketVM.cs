using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using flicket.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace flicket.Models.ViewModels
{

    public class AddTicketVM
    {
        [Required]
        public int FlightId { get; set; }
        [Required]
        public SeatClass SeatClass { get; set; }
        public string Position { get; set; }
        public IEnumerable<SelectListItem> Flights { get; set; }
        public IEnumerable<SelectListItem> SeatClasses { get; set; }
    }
}
