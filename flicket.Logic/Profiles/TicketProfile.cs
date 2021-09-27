using AutoMapper;
using flicket.Models.Entities;
using flicket.Models.ViewModels;

namespace flicket.Logic.Profiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketListVM>()
                .ForMember(dest => dest.SeatClass, opt => opt.MapFrom(src => src.Seat.SeatClass))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Seat.Position));
        }
    }
}
