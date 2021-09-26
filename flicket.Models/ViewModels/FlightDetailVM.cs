using System;
using flicket.Models.Entities;

namespace flicket.Models.ViewModels
{
    public class FlightDetailVM
    {
        public int Id { get; set; }
        public AirportVM From { get; set; }
        public AirportVM To { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public double BusinessPrice { get; set; }
        public double EconomyPrice { get; set; }
        public AirlineVM Airline { get; set; }
    }
}
