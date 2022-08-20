using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NcryptX_Proxy.classes.Core;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;

namespace NcryptX_Proxy
{
    public class EWS
    {
        private readonly HttpClient _httpClient;
        private readonly RequestDelegate _nextMiddleware;
        private readonly ILogger _logger;

        public EWS()
        {

        }
        public EWS(RequestDelegate nextMiddleware, ILogger<EWS> logger, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _nextMiddleware = nextMiddleware;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            ServicePointManager.MaxServicePointIdleTime = Timeout.Infinite;
            BuildTargetUri targetUri = new BuildTargetUri();
            var urls = targetUri.BuldURI(context.Request);
            BuildTargetMessage targetReqMessage = new BuildTargetMessage();
            var targetreqmsg = targetReqMessage.CreateTargetMessage(context, urls);
            var responseMessage = await _httpClient.SendAsync(targetreqmsg, HttpCompletionOption.ResponseContentRead, context.RequestAborted);

            try
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
                context.Response.StatusCode = (int)responseMessage.StatusCode;
                await responseMessage.Content.CopyToAsync(context.Response.Body);
                responseMessage.Content.Headers.Clear();
                var exception = "Sucessfully Called EWS";
                _logger.LogDebug(exception);

              /*  context.Response.OnCompleted(async () =>
                {
                    // Put breakpoint here.
                    _logger.LogDebug("This request is now ended");
                    return;
                    //await _nextMiddleware(context);

                });*/
            }


            catch (Exception e)
            {

                var exception = e.ToString();
                _logger.LogDebug(exception + "This is from Autodiscover validation");


            }



            return;


        }


    }


}

