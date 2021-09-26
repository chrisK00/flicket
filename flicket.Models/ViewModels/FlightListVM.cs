using System;

namespace flicket.Models.ViewModels
{
    public class FlightListVM
    {
        public int Id { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public double BusinessPrice { get; set; }
        public double EconomyPrice { get; set; }
        public AirportVM From { get; set; }
        public AirportVM To { get; set; }
        public string Airline { get; set; }
    }
}
