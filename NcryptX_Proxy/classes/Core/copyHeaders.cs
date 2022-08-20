using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net.Http;

namespace NcryptX_Proxy.classes.Core
{
    public class copyHeaders
    {
        public copyHeaders()
        {

        }

        public void CopyFromTargetResponseHeaders(HttpContext context, HttpResponseMessage responseMessage)
        {
            foreach (var header in responseMessage.Headers)
            {
                context.Response.Headers[header.Key] = header.Value.ToArray();
            }

            foreach (var header in responseMessage.Content.Headers)
            {
                context.Response.Headers[header.Key] = header.Value.ToArray();
            }
            context.Response.Headers.Remove("transfer-encoding");
            //context.Response.Headers.Add("transfer-encoding","chunked");
        }
    }
}
