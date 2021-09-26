using AutoMapper;
using flicket.Models.Entities;
using flicket.Models.ViewModels;

namespace flicket.Logic.Profiles
{
    public class AirlineProfiles : Profile
    {
        public AirlineProfiles()
        {
            CreateMap<Airline, AirlineVM>();
        }
    }
}
