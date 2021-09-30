using System.ComponentModel.DataAnnotations;

namespace flicket.Models.Params
{
    public class FlightParams
    {
        [Range(1, 10)]
        public int Passengers { get; set; } = 1;
        public int? CompanyId { get; set; }
    }
}
