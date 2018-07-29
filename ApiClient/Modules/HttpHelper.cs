using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ApiClient.Modules
{
    class HttpHelper
    {
        public HttpWebRequest CreateWebRequest(string path, string contentType, string method, int timeout)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(path);
            if (contentType != null)
                httpWebRequest.ContentType = contentType;
            httpWebRequest.Method = method;
            httpWebRequest.Timeout = timeout;

            return httpWebRequest;
        }
    }
}
