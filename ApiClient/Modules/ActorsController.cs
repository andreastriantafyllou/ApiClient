using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ApiClient.Interafeces;
using ApiClient.Models;
using Newtonsoft.Json;

namespace ApiClient.Modules
{
    public class ActorsController : ICrud<ActorModel>
    {
        MoviesDBController db;
        public ActorsController()
        {
            db = new MoviesDBController();
        }
        public string Create(ActorModel obj)
        {
            throw new NotImplementedException();
        }

        public string Delete(string key)
        {
            throw new NotImplementedException();
        }

        public List<ActorModel> ReadAll()
        {
            var httpResponse = db.CreateWebRequest(db.moviesDbScheme.ActorsPath, Settings.GetContentType, Settings.GetMethodGet, Settings.GetTimeoutResponse).GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<ActorModel>>(result);
            }
        }

        public ActorModel ReadById(string id)
        {
            throw new NotImplementedException();
        }

        public string Update(string key)
        {
            throw new NotImplementedException();
        }
    }
}
