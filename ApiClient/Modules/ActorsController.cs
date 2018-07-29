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
    public class ActorsController : ICrud<ActorModel>
    {
        MoviesDBController db;
        SharedCrudController crud;

        public ActorsController()
        {
            db = new MoviesDBController();
            crud = new SharedCrudController();
        }

        public string Create(ActorModel obj)
        {
            return crud.Create(obj, db.moviesDbScheme.ActorsPath);
        }

        public string Delete(int id)
        {
            return crud.Delete(id, db.moviesDbScheme.ActorsPath + id.ToString() + "/");
        }

        public List<ActorModel> ReadAll()
        {
            return JsonConvert.DeserializeObject<List<ActorModel>>(crud.ReadAll(db.moviesDbScheme.ActorsPath));
        }

        public ActorModel ReadById(int id)
        {
            return JsonConvert.DeserializeObject<ActorModel>(crud.ReadById(id, db.moviesDbScheme.ActorsPath + id.ToString() + "/"));
        }

        public string Update(int id, ActorModel newObj)
        {
            return crud.Update(id, newObj, db.moviesDbScheme.ActorsPath + id.ToString() + "/");
        }
    }
}
