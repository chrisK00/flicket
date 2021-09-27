using System;

namespace flicket.Models.ViewModels
{
    public class TicketListVM
    {
        public int Id { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public double Price { get; set; }
        public SeatClass SeatClass { get; set; }
        public string Position { get; set; }
    }
}
