using Musala.GatewayMgmt.Model.Dtos;
using System;
using System.Linq.Expressions;

namespace Musala.GatewayMgmt.SystemInterfaces.Services
{
    public interface IService<T, K> where T : ItemDto<K>
    {
        GetItemDtosOutput<T> GetAll();

        T FindById(K id);

        void Remove(K id);
    }
}
