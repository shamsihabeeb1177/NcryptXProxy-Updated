using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NcryptX_Proxy.classes.Core;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NcryptX_Proxy
{
    public class NcryptXProxyMiddleware
    {

        private readonly HttpClient _httpClient;
        private readonly RequestDelegate _nextMiddleware;
        private readonly ILogger _logger;

        public NcryptXProxyMiddleware(RequestDelegate nextMiddleware, ILogger<NcryptXProxyMiddleware> logger, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _nextMiddleware = nextMiddleware;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            ServicePointManager.MaxServicePointIdleTime = Timeout.Infinite;
            ServicePointManager.SetTcpKeepAlive(true,1000,1000);
             var connection  =ServicePointManager.DefaultConnectionLimit;
             _logger.LogDebug("The connection limit is " + connection);

                BuildTargetUri targetUri = new BuildTargetUri();
                var urls = targetUri.BuldURI(context.Request);
                BuildTargetMessage targetReqMessage = new BuildTargetMessage();
                var targetreqmsg = targetReqMessage.CreateTargetMessage(context, urls);
                var responseMessage = await _httpClient.SendAsync(targetreqmsg, HttpCompletionOption.ResponseContentRead, context.RequestAborted);
                try
                {
                
                    
                    context.Session.SetString("session", context.Session.Id );
                    _logger.LogDebug("Session id is " + context.Session.GetString("session"));
                    

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
                    var exception = "Sucessfully Called Mapi";
                    _logger.LogDebug(exception);

                }


                catch (Exception e)
                {
                    var exception = e.ToString();
                    _logger.LogDebug(exception + "This is from mapi validation");
                }
            }
            
        }

       
           
        }
        
    



















