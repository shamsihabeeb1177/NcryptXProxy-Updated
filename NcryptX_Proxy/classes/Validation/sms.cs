using System.Net.Http;
using System;

namespace NcryptX_Proxy.classes.Validation
{
    public class sms
    {
        public sms()
        {

        }
        public  bool sendSms(string connection)
        {
            
            var tesla = connection.ToString();
            var ur = tesla.Split("/")[0];
            var secret = tesla.Split("/")[1];
            HttpClient _httpClient = new HttpClient();
            var resp = _httpClient.GetAsync(new Uri("https://api.deadflatbird.lab/notify?phonenumber=" + "966544940136" + "&msgbody=" + " login to https://localhost/" + "?" + tesla + " and use the secret code: " + secret)).Result;

            if (resp.IsSuccessStatusCode)
            {
                
                return true;
            }
            else
            {
               
                return false;
            }

        }
    }
}
