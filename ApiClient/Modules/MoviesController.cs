using System;
using System.Collections.Generic;
using System.Text;
using ApiClient.Interafeces;
using ApiClient.Models;
using Newtonsoft.Json;

namespace ApiClient.Modules
{
    public class MoviesController : ICrud<MovieModel>
    {
        MoviesDBController db;
        SharedCrudController crud;

        public MoviesController()
        {
            db = new MoviesDBController();
            crud = new SharedCrudController();
        }

        public string Create(MovieModel obj)
        {
            return crud.Create(obj, db.moviesDbScheme.MoviesPath);
        }

        public string Delete(int id)
        {
            return crud.Delete(id, db.moviesDbScheme.MoviesPath + id.ToString() + "/");
        }

        public List<MovieModel> ReadAll()
        {
            return JsonConvert.DeserializeObject<List<MovieModel>>(crud.ReadAll(db.moviesDbScheme.MoviesPath));
        }

        public MovieModel ReadById(int id)
        {
            return JsonConvert.DeserializeObject<MovieModel>(crud.ReadById(id, db.moviesDbScheme.MoviesPath + id.ToString() + "/"));
        }

        public string Update(int id, MovieModel newObj)
        {
            return crud.Update(id, newObj, db.moviesDbScheme.MoviesPath + id.ToString() + "/");
        }
    }
}
