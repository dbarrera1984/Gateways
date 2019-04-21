using Musala.GatewayMgmt.Model.Dtos.Devices;
using System;
using System.Collections.Generic;

namespace Musala.GatewayMgmt.Model.Dtos.Gateways
{
    public class CreateGatewayInput
    {
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string IPv4 { get; set; }

        public List<CreateDeviceInput> Devices { get; set; }
    }
}
