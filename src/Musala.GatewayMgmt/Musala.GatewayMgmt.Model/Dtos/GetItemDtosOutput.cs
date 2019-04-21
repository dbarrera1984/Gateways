using System.Collections.Generic;

namespace Musala.GatewayMgmt.Model.Dtos
{
    public class GetItemDtosOutput<T, TK>
    {
        public GetItemDtosOutput()
        {
            Items = new List<T>();
        }

        public List<T> Items { get; }
    }
}
