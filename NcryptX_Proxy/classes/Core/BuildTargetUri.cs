using Microsoft.AspNetCore.Http;
using System;

namespace NcryptX_Proxy.classes.Core
{
    public class BuildTargetUri
    {

        public Uri BuldURI(HttpRequest request)
        {
            Uri targetUri = null;

            if (request.Path.StartsWithSegments("", out var remainingPath))
            {
                targetUri = new Uri("https://" + request.Host.ToString() + remainingPath + request.QueryString);
            }

            return targetUri;
        }
    }
}
