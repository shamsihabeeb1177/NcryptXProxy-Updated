using Microsoft.AspNetCore.Http;
using System;

namespace NcryptX_Proxy.classes.Validation
{
    public class getUserName
    {

        public string getusername(HttpContext context)
        {
            
                
                String username = "NcryptXDefault";
                foreach (var header in context.Request.Headers)
                {

                    if (header.Key == "X-User-Identity")
                    {
                        username = header.Value;
                    }
                    if (header.Key == "X-AnchorMailbox")
                    {
                        username = header.Value;
                    }


                }
                return null;
            }
            

        }
    }


