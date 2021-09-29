using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace flicket.Models.ViewModels
{
    public class AddFlightVM
    {
        public IEnumerable<SelectListItem> Airports { get; set; }
        public IEnumerable<SelectListItem> Airlines { get; set; }

        [Required]
        public int AirportFromId { get; set; }

        [Required]
        public int AirlineId { get; set; }

        [Required]
        public int AirportToId { get; set; }

        [Required]       
        public DateTime Departure { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime Arrival { get; set; } = DateTime.UtcNow.AddHours(5);

        [Required]
        public double BusinessPrice { get; set; }

        [Required]
        public double EconomyPrice { get; set; }
    }
}