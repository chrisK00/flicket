using System;
using flicket.Models.Params;

namespace flicket.Models.ViewModels
{
    public class FlightListVM
    {
        public int Id { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public double BusinessPrice { get; set; }
        public double EconomyPrice { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Airline { get; set; }
        public TimeSpan Duration => Arrival - Departure;
        public FlightParams FlightParams { get; set; }
    }
}
