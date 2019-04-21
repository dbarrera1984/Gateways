using AutoMapper;
using Musala.GatewayMgmt.Model.Dtos.Devices;
using Musala.GatewayMgmt.Model.Entities;

namespace Musala.GatewayMgmt.Mapper
{
    public class DeviceMapperProfile : Profile
    {
        public DeviceMapperProfile()
        {
            CreateMap<Device, DeviceDto>()
                .ForMember(d => d.StatusCode, o => o.Ignore())
                .ForMember(d => d.StatusMessage, o => o.Ignore())
                .ReverseMap();

            CreateMap<Device, DeviceDetailDto>()
                .ForMember(d => d.GatewayName, o => o.MapFrom(s => s.Gateway == null ? "" : s.Gateway.Name))
                .ForMember(d => d.StatusCode, o => o.Ignore())
                .ForMember(d => d.StatusMessage, o => o.Ignore())
                .ReverseMap();

            CreateMap<CreateDeviceInput, Device>()
                .ForMember(d => d.UID, o => o.MapFrom(s => s.UID))
                .ForMember(d => d.Vendor, o => o.MapFrom(s => s.Vendor))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status))
                .ForMember(d => d.GatewayId, o => o.MapFrom(s => s.GatewayId))
                .ForAllOtherMembers(f => f.Ignore());
        }
    }
}