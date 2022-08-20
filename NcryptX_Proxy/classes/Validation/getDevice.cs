using Microsoft.AspNetCore.Http;
using System;

namespace NcryptX_Proxy.classes.Validation
{
    public class getDevice
    {
        public string getdevice(HttpContext context)
        {
           
                

                String deviceid = "1122334455667788";

                foreach (var header in context.Request.Headers)
                {


                    if (header.Key == "X-ClientInfo")
                    {
                        deviceid = header.Value;
                    }
                    else
                    {
                        return null;
                    }


                }
                return null;
            
           
            
        } 
                
            
    }
}
