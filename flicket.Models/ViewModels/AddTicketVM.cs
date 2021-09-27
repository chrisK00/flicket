using System.ComponentModel.DataAnnotations;
using flicket.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace flicket.Models.ViewModels
{
    public class AddTicketVM
    {
        public int FlightId { get; set; }
        public SeatVM Seat { get; set; }
        [Required]
        public SelectList Flights { get; set; }
    }
}
