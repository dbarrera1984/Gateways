using Musala.GatewayMgmt.Model.Enums;
using System;

namespace Musala.GatewayMgmt.Model.Dtos.Devices
{
    public class DeviceDetailDto : DeviceDto
    {
        public string Vendor { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }

        #region Related Data

        public int GatewayId { get; set; }
        public string GatewayName { get; set; }
        
        #endregion
    }
}
