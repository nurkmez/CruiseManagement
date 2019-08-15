using AutoMapper;
using CruiseManagement.API.Entities;

namespace CruiseManagement.API
{
    public class CruiseProfile : Profile
    {
        public CruiseProfile()
        {
            CreateMap<Entities.Cruise, Dtos.Cruise>();
            CreateMap<Entities.CruiseLine, Dtos.CruiseLine>();
            CreateMap<Entities.Ship, Dtos.Ship>();
            CreateMap<Entities.CabinType, Dtos.CabinType>();
            CreateMap<Dtos.CruiseForCreation, Entities.Cruise>();
            CreateMap<Dtos.RouteForCreation, Entities.Route>();
            CreateMap<Dtos.CruiseWithRoutesForCreation, Entities.Cruise>();
            


            //  CreateMap<IEnumerable< Dtos.CruiseLine>, IEnumerable<Entities.CruiseLine>>();

            //.ForMember(d => d.CruiseLine, o => o.MapFrom(s => s.CruiseLine.Id))
            //.ForMember(d => d.Ship, o => o.MapFrom(s => s.Ship.Id))
            //.ForMember(d => d.CabinType, o => o.MapFrom(s => s.CabinType.Id));



        }
    }
}
