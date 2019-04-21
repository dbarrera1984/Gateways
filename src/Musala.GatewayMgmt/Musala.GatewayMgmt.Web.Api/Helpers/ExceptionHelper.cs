using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Musala.GatewayMgmt.Web.Api.Helpers
{
    public static class ExceptionHelper
    {
        public static void ThrowException(Exception e)
        {
            var sb = new StringBuilder();

            sb.AppendLine("An error ocurred, please try again");
            if (Debugger.IsAttached)
            {
                sb.AppendLine("");
                sb.AppendLine($"{e.Message}");
                sb.AppendLine($"{e.StackTrace}");
                sb.AppendLine("");
                sb.AppendLine($"{e.InnerException?.Message}");
                sb.AppendLine($"{e.InnerException?.StackTrace}");
                sb.AppendLine("");
                sb.AppendLine($"{e.InnerException?.InnerException?.Message}");
                sb.AppendLine($"{e.InnerException?.InnerException?.StackTrace}");
            }
            throw new HttpResponseException(
                new HttpResponseMessage(
                    HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(sb.ToString()),
                    ReasonPhrase = "Critical exception"
                });
        }
    }
}