using AutoMapper;
using flicket.Models.Entities;
using flicket.Models.ViewModels;

namespace flicket.Logic.Profiles
{
    public class AirlineProfile : Profile
    {
        public AirlineProfile()
        {
            CreateMap<Airline, AirlineVM>();
        }
    }
}
