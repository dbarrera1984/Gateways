using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musala.GatewayMgmt.Model.Dtos.Devices
{
    public class DeviceDto : ItemDto<int>
    {
        public long UID { get; set; }
    }
}
