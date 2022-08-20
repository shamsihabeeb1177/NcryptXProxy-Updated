using System.Net.Http;
using System;
using Microsoft.Extensions.Logging;

namespace NcryptX_Proxy.classes.Validation
{
    public class validate
    {

        private readonly ILogger _logger;

        public validate()
        {

        }
        public validate(ILogger<validate> logger)
        {
            _logger = logger;
        }
        public string Validate(string username, string deviceid)

        {

            string newdevid = deviceid.Split('}')[0];
            HttpClient _httpClient = new HttpClient();
            var resp = _httpClient.GetAsync(new Uri("https://api.deadflatbird.lab/api/get?username=" + username + "&deviceid=" + newdevid + "&mobile=966544940136")).Result;
            string cont = resp.Content.ReadAsStringAsync().Result;
            _logger.LogInformation(cont + "************"+ "response of cont");
            return cont;

        }
    }
}
