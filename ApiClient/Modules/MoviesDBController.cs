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
        HttpHelper httpHelper;

        public MoviesDBController()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            httpHelper = new HttpHelper();
            moviesDbScheme = GetMoviesDBScheme();
        }

        private MoviesDBScheme GetMoviesDBScheme()
        {
            try
            {
                var httpResponse = httpHelper.CreateWebRequest(Settings.GetClientRoute, Settings.GetContentType, Settings.GetMethodGet, Settings.GetTimeoutResponse).GetResponse();
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
