using System.Collections.Generic;
using System.Net;

namespace Musala.GatewayMgmt.Model.Dtos
{
    public class GetItemDtosOutput<T>
    {
        public GetItemDtosOutput()
        {
            Items = new List<T>();
        }

        public List<T> Items { get; }

        public HttpStatusCode StatusCode { get; set; }
        public string StatusMessage { get; set; }
    }
}
