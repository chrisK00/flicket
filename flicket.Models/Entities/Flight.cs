using System;

namespace flicket.Models.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public Airport From { get; set; }
        public Airport To { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public double BusinessPrice { get; set; }
        public double EconomyPrice { get; set; }
        public Airline Airline { get; set; }
        public int CompanyId { get; set; }
        public bool Cancelled { get; set; }
    }
}
