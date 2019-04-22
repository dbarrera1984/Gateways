using Musala.GatewayMgmt.Model.Dtos.Devices;

namespace Musala.GatewayMgmt.SystemInterfaces.Services
{
    public interface IDeviceService : IService<DeviceDetailDto, int>
    {
        DeviceDetailDto Add(CreateDeviceInput input);

        GetDevicesOutput GetAllByGateway(int gatewayId);
        GetDevicesOutput GetAllWithGatewayInfo();

        DeviceDetailDto FindByIdWithGatewayInfo(int id);
    }
}
