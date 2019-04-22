using Musala.GatewayMgmt.Model.Dtos.Gateways;
using System;

namespace Musala.GatewayMgmt.SystemInterfaces.Services
{
    public interface IGatewayService : IService<GatewayDetailDto, int>
    {
        GatewayDetailDto Add(CreateGatewayInput input);
        GetGatewaysOutput GetAllWithDeviceInfo();
    }
}
