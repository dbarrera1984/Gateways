using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musala.GatewayMgmt.Model.Dtos.Gateways
{
    public class GatewayDto : ItemDto<int>
    {
        public string Name { get; set; }
    }
}
