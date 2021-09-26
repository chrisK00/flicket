using AutoMapper;
using flicket.Models.Entities;
using flicket.Models.ViewModels;

namespace flicket.Models.Profiles
{
    public class FlightProfiles : Profile
    {
        public FlightProfiles()
        {
            CreateMap<Flight, FlightDetailVM>();
            CreateMap<Flight, FlightListVM>();
        }
    }
}
