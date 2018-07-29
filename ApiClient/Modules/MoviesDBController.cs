using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using ApiClient.Interafeces;
using ApiClient.Models;
using Newtonsoft.Json;

namespace ApiClient.Modules
{
    public class MoviesDBController
    {
        public MoviesDBScheme moviesDbScheme = new MoviesDBScheme();
        
        public MoviesDBController()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            moviesDbScheme = GetMoviesDBScheme();
        }

        private MoviesDBScheme GetMoviesDBScheme()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Settings.GetClientRoute);
                httpWebRequest.ContentType = Settings.GetContentType;
                httpWebRequest.Method = "GET";
                httpWebRequest.Timeout = Settings.GetTimeoutResponse;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    return JsonConvert.DeserializeObject<MoviesDBScheme>(result);
                }
            }
            catch (Exception e)
            {
                //Error Handle
            }
            return null;
        }

        
    }
}
