using AutoMapper;
using CruiseManagement.API.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CruiseManagement.API
{
    public class CruiseProfile : Profile
    {
        public CruiseProfile()
        {
            CreateMap<Entities.Cruise, Dtos.Cruise>();
            // .ForMember(dest => dest.CruiseLineName, opt => opt.MapFrom(s => s.CruiseLine.Title))
            // .ForMember(dest => dest.ShipName, opt => opt.MapFrom(s => s.Ship.Title))
            // .ForMember(dest => dest.CabinTypeName, opt => opt.MapFrom(s => s.CabinType.Title));

            CreateMap<Entities.Cruise, Dtos.CruiseForList>()
             .ForMember(dest => dest.CruiseLineName, opt => opt.MapFrom(s => s.CruiseLine.Title))
             .ForMember(dest => dest.ShipName, opt => opt.MapFrom(s => s.Ship.Title))
             .ForMember(dest => dest.CabinTypeName, opt => opt.MapFrom(s => s.CabinType.Title));

            CreateMap<Entities.CruiseLine, Dtos.CruiseLine>();
            CreateMap<Entities.Ship, Dtos.Ship>();
            CreateMap<Entities.Route, Dtos.Route>();
            CreateMap<Dtos.Route, Entities.Route>();

            //.ForMember(dest => dest.PortName, opt => opt.MapFrom(s => s.Port.Title));

            CreateMap<Entities.Route, Dtos.RouteForList>()
                .ForMember(dest => dest.PortName, opt => opt.MapFrom(s => s.Port.Title));

            CreateMap<Entities.CabinType, Dtos.CabinType>();
            CreateMap<Dtos.CruiseWithRoutes, Entities.Cruise>();

            CreateMap<Dtos.CruiseForCreation, Entities.Cruise>();
            CreateMap<Dtos.RouteForCreation, Entities.Route>();
            CreateMap<Dtos.CruiseWithRoutesForCreation, Entities.Cruise>();
            CreateMap<Dtos.CruiseWithRoutesForUpdate, Entities.Cruise>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.ShipId, opt => opt.MapFrom(s => s.ShipId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(dest => dest.DepartureDate, opt => opt.MapFrom(s => s.DepartureDate))
                .ForMember(dest => dest.CabinTypeId, opt => opt.MapFrom(s => s.CabinTypeId))
                .ForMember(dest => dest.CruiseLineId, opt => opt.MapFrom(s => s.CruiseLineId))
                .ForMember(dest => dest.FlightIncluded, opt => opt.MapFrom(s => s.FlightIncluded))
                .ForMember(dest => dest.Routes,   opt => opt.MapFrom(src => src.Routes));





            CreateMap<Entities.Cruise, Dtos.CruiseWithRoutes>();
     
            CreateMap<IEnumerable<Dtos.Route>, Dtos.CruiseWithRoutes>()
                .ForMember(dest => dest.Routes, opt => opt.MapFrom(src => src));

            CreateMap<IEnumerable<Dtos.RouteForList>, Dtos.CruiseWithRoutesWithPortName>()
                .ForMember(dest => dest.Routes, opt => opt.MapFrom(src => src));





            //  CreateMap<IEnumerable< Dtos.CruiseLine>, IEnumerable<Entities.CruiseLine>>();

            //.ForMember(d => d.CruiseLine, o => o.MapFrom(s => s.CruiseLine.Id))
            //.ForMember(d => d.Ship, o => o.MapFrom(s => s.Ship.Id))
            //.ForMember(d => d.CabinType, o => o.MapFrom(s => s.CabinType.Id));



        }
    }
}
