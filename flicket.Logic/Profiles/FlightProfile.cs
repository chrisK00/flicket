using AutoMapper;
using flicket.Models.Entities;
using flicket.Models.ViewModels;

namespace flicket.Logic.Profiles
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightDetailVM>();
            CreateMap<Flight, FlightListVM>()
                .ForMember(dest => dest.Airline, opt => opt.MapFrom(src => src.Airline.Name))
                .ForMember(dest => dest.From, opt => opt.MapFrom(src => $"{src.From.Location} ({src.From.Name})"))
                .ForMember(dest => dest.To, opt => opt.MapFrom(src => $"{src.To.Location} ({src.To.Name})"));
        }
    }
}
