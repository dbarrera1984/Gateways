using Musala.GatewayMgmt.Model.Dtos.Devices;
using System;
using System.Collections.Generic;

namespace Musala.GatewayMgmt.Model.Dtos.Gateways
{
    public class GatewayDetailDto : GatewayDto
    {
        public string SerialNumber { get; set; }
        public string IPv4 { get; set; }

        #region Related Data

        List<DeviceDetailDto> Devices { get; set; }
        
        #endregion
    }
}
