using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TanvirArjel.CustomValidation.Attributes;

namespace flicket.Models.ViewModels
{
    public class AddFlightVM
    {
        public IEnumerable<SelectListItem> Airports { get; set; }
        public IEnumerable<SelectListItem> Airlines { get; set; }

        [Required(ErrorMessage = "From airport  is required")]
        public int AirportFromId { get; set; }

        [Required(ErrorMessage = "Airline is required")]
        public int AirlineId { get; set; }

        [Required(ErrorMessage = "To airport is required")]
        public int AirportToId { get; set; }

        [Required, CompareTo(nameof(Arrival), ComparisonType.SmallerThan, ErrorMessage = "You need to depart before you arrive")]       
        public DateTime Departure { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime Arrival { get; set; } = DateTime.UtcNow.AddHours(5);

        [Required, DisplayName("Business Price"), Range(1, double.MaxValue)]
        public double BusinessPrice { get; set; }

        [Required, DisplayName("Economy Price"), Range(1, double.MaxValue)]
        public double EconomyPrice { get; set; } 
    }
}