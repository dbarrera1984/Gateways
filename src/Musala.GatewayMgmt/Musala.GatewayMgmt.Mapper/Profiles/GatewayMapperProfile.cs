using AutoMapper;
using Musala.GatewayMgmt.Model.Dtos.Gateways;
using Musala.GatewayMgmt.Model.Entities;

namespace Musala.GatewayMgmt.Mapper
{
    public class GatewayMapperProfile : Profile
    {
        public GatewayMapperProfile()
        {
            CreateMap<Gateway, GatewayDto>()
                .ForMember(d => d.StatusCode, o => o.Ignore())
                .ForMember(d => d.StatusMessage, o => o.Ignore())
                .ReverseMap();

            CreateMap<Gateway, GatewayDetailDto>()
                .ForMember(d => d.StatusCode, o => o.Ignore())
                .ForMember(d => d.StatusMessage, o => o.Ignore())
                .ReverseMap();

            CreateMap<CreateGatewayInput, Gateway>()
                .ForMember(d => d.SerialNumber, o => o.MapFrom(s => s.SerialNumber))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.IPv4, o => o.MapFrom(s => s.IPv4))
                .ForMember(d => d.Devices, o => o.MapFrom(s => s.Devices))
                .ForAllOtherMembers(f => f.Ignore());
        }
    }
}