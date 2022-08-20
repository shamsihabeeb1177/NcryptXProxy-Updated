using Microsoft.AspNetCore.Http;
using NcryptX_Proxy.classes.Core;
using System;
using System.Net.Http;

namespace NcryptX_Proxy.classes.Validation
{
    public class mapiHandler
    {

        public mapiHandler()
        {

        }
        public bool mapi(HttpContext context, HttpResponseMessage resp)
        {

            getUserName gu = new getUserName();
            var username = gu.getusername(context);
            getDevice gd = new getDevice();
            var device = gd.getdevice(context);
            return true;
        }
    }
}
                //validate val = new validate();
                //var cont = val.Validate(username,device);
        /*    try
            {


                if (cont != null && cont == "Pending" || cont == "Not Found" || cont == "state set to pending")
                {
                    if (username != null && device != null)
                    {
                        connecttionString constr = new connecttionString();
                        if (constr.getConnectionString(username, device) != "failed" && constr.getConnectionString(username, device) != null)
                        {
                            sms s = new sms();
                            s.sendSms(constr.getConnectionString(username, device));

                        }
                    }
                    return false;
                }

                if (cont == "Active")
                {

                    return true;
                }
            }catch(Exception e)
            {
                
            }
            return false;
            }

        }*/
         
                
   // }

