using AutoMapper;
using flicket.Models.Entities;
using flicket.Models.ViewModels;

namespace flicket.Logic.Profiles
{
    public class AirportProfiles : Profile
    {
        public AirportProfiles()
        {
            CreateMap<Airport, AirportVM>();
        }
    }
}
