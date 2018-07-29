using System;
using System.Collections.Generic;
using System.Text;
using ApiClient.Interafeces;
using ApiClient.Models;
using Newtonsoft.Json;

namespace ApiClient.Modules
{
    public class DirectorsController : ICrud<DirectorModel>
    {
        MoviesDBController db;
        SharedCrudController crud;

        public DirectorsController  ()
        {
            db = new MoviesDBController();
            crud = new SharedCrudController();
        }

        public string Create(DirectorModel obj)
        {
            return crud.Create(obj, db.moviesDbScheme.DirectorsPath);
        }

        public string Delete(int id)
        {
            return crud.Delete(id, db.moviesDbScheme.DirectorsPath + id.ToString() + "/");
        }

        public List<DirectorModel> ReadAll()
        {
            return JsonConvert.DeserializeObject<List<DirectorModel>>(crud.ReadAll(db.moviesDbScheme.DirectorsPath));
        }

        public DirectorModel ReadById(int id)
        {
            return JsonConvert.DeserializeObject<DirectorModel>(crud.ReadById(id, db.moviesDbScheme.DirectorsPath + id.ToString() + "/"));
        }

        public string Update(int id, DirectorModel newObj)
        {
            return crud.Update(id, newObj, db.moviesDbScheme.DirectorsPath + id.ToString() + "/");
        }
    }
}
