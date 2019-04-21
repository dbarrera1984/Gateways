using Musala.GatewayMgmt.Model.Enums;

namespace Musala.GatewayMgmt.Model.Dtos.Devices
{
    public class CreateDeviceInput
    {
        public long UID { get; set; }
        public string Vendor { get; set; }
        public Status Status { get; set; }
        public int GatewayId { get; set; }
    }
}
