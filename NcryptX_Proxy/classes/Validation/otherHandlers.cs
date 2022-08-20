using Microsoft.AspNetCore.Http;
using NcryptX_Proxy.classes.Core;
using System.Net.Http;

namespace NcryptX_Proxy.classes.Validation
{
    public class otherHandlers
    {

        public async void handler(HttpContext context, HttpResponseMessage resp)
        {
            context.Session.SetString("session", context.Session.Id);
            context.Response.StatusCode = (int)resp.StatusCode;
            copyHeaders copyHeaders = new copyHeaders();
            copyHeaders.CopyFromTargetResponseHeaders(context, resp);
            await resp.Content.CopyToAsync(context.Response.Body);
            resp.Content.Headers.Clear();
            return;
        }
       
    }
}
