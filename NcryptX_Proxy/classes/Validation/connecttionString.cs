using System.Net.Http;
using System;

namespace NcryptX_Proxy.classes.Validation
{
    public class connecttionString
    {
        public string getConnectionString(string username, string deviceid)
        {

            if (username != null && deviceid != null && username != "test" && deviceid != "test")
            {
                string newdevid = deviceid.Split('}')[0];
                HttpClient _httpClient = new HttpClient();
                var resp = _httpClient.GetAsync(new Uri("https://api.deadflatbird.lab/api/getConnectionString?" + "username=" + username + "&" + "deviceid=" + newdevid)).Result;
                //below code is causing problem in sending sms

                string test = resp.Content.ReadAsStringAsync().Result;
                

                return test.ToString();

                //problamatic code ends here
            }

            return "failed";
        }
    }
}
