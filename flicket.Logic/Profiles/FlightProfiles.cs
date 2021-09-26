using AutoMapper;
using flicket.Models.Entities;
using flicket.Models.ViewModels;

namespace flicket.Logic.Profiles
{
    public class FlightProfiles : Profile
    {
        public FlightProfiles()
        {
            CreateMap<Flight, FlightDetailVM>();
            CreateMap<Flight, FlightListVM>().ForMember(dest => dest.Airline, opt => opt.MapFrom(src =>  src.Airline.Name));
        }
    }
}
