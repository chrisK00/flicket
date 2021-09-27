using System.ComponentModel.DataAnnotations;

namespace flicket.Models.ViewModels
{
    public class SeatVM
    {
        [Required]
        public SeatClass SeatClass { get; set; }
        public string Position { get; set; }
    }
}