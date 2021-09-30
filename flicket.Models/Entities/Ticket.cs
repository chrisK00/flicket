using System;

namespace flicket.Models.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public double Price { get; set; }
        public Seat Seat { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int SecurityNumber { get; set; }
        public int CompanyId { get; set; }
    }
}
