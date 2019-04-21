
using Musala.GatewayMgmt.Model.Entities;
using Musala.Infrastructure;
using System;

namespace Musala.GatewayMgmt.Interfaces.DataAccess.Repositories
{
    public interface IDeviceRepository : IRepository<Device, int>
    {
    }
}
