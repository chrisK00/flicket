namespace flicket.Models.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public SeatClass SeatClass { get; set; }
        public string Position { get; set; }
    }
}