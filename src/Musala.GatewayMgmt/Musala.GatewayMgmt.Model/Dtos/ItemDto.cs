using System.Collections.Generic;
using System.Net;

namespace Musala.GatewayMgmt.Model.Dtos
{
    public class ItemDto<T>
    {
        public T Id { get; set; }

        public HttpStatusCode StatusCode { get; set; }
        public string StatusMessage { get; set; }
    }

    // TODO: Pending to implement

    //public class Link
    //{
    //    public string Rel { get; set; }
    //    public string HRef { get; set; }
    //}
    //public abstract class LinkedResource
    //{
    //    public List<Link> Links { get; set; }
    //    public string HRef { get; set; }
    //}
    //public abstract class LinkedResourceCollection<T> : LinkedResource,
    //  ICollection<T> where T : LinkedResource
    //{
    //    // Rest of the collection implementation
    //}
}
