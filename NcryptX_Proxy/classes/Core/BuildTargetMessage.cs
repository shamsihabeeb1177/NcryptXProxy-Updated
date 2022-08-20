using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System;

namespace NcryptX_Proxy.classes.Core
{
    public class BuildTargetMessage
    {


        public  HttpRequestMessage CreateTargetMessage(HttpContext context, Uri targetUri)
        {
            var requestMessage = new HttpRequestMessage();
            CopyContent copyContent = new CopyContent();

            copyContent.CopyFromOriginalRequestContentAndHeaders(context, requestMessage);
            getMethod getmethod = new getMethod();
            requestMessage.RequestUri = targetUri;
            requestMessage.Headers.Host = targetUri.Host;
            requestMessage.Method = getmethod.GetMethod(context.Request.Method);
            requestMessage.Headers.Add("Connection", "Keep-Alive");

            foreach (var header in context.Request.Headers)
            {
                if (header.Key == "Authorization" || header.Key == "authorization")
                {
                    string[] t = header.Value.ToArray();
                    requestMessage.Headers.Add(header.Key, t[0]);
                }
            }

            
            return requestMessage;
        }
    }
}
