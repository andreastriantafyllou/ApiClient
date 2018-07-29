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
    class MoviesDBController
    {
        private static MoviesDBController instance = null;
        private static readonly object padlock = new object();
        public MoviesDBScheme moviesDbScheme = new MoviesDBScheme();

        public static MoviesDBController Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new MoviesDBController();
                        }
                    }
                }
                return instance;
            }
        }

        MoviesDBController()
        {
            moviesDbScheme = GetMoviesDBScheme();
        }

        private MoviesDBScheme GetMoviesDBScheme()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Settings.GetClientRoute);
                httpWebRequest.ContentType = Settings.GetContentType;
                httpWebRequest.Method = "GET";
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
