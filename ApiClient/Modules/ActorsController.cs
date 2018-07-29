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
        public ActorsController()
        {
            db = new MoviesDBController();
        }

        public string Create(ActorModel obj)
        {
            var httpWebRequest = db.CreateWebRequest(db.moviesDbScheme.ActorsPath, Settings.GetContentType, Settings.GetMethodPost, Settings.GetTimeoutResponse);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(obj);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            return ((HttpWebResponse)httpWebRequest.GetResponse()).StatusCode.ToString();
        }

        public string Delete(int id)
        {
            try
            {
                var httpWebRequest = db.CreateWebRequest(db.moviesDbScheme.ActorsPath + id.ToString() + "/", null, Settings.GetMethodDelete, Settings.GetTimeoutResponse);
                return ((HttpWebResponse)httpWebRequest.GetResponse()).StatusCode.ToString();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    throw new Exception("The item does not exist or path error.", ex);
                }
                else
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ActorModel> ReadAll()
        {
            var httpWebRequest = db.CreateWebRequest(db.moviesDbScheme.ActorsPath, Settings.GetContentType, Settings.GetMethodGet, Settings.GetTimeoutResponse).GetResponse();
            if (((HttpWebResponse)httpWebRequest).StatusCode == HttpStatusCode.OK)
            {
                using (var streamReader = new StreamReader(httpWebRequest.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<ActorModel>>(result);
                }
            }
            else
            {
                throw new Exception(((HttpWebResponse)httpWebRequest).StatusCode.ToString());
            }
        }

        public ActorModel ReadById(int id)
        {
            try
            {
                var httpWebRequest = db.CreateWebRequest(db.moviesDbScheme.ActorsPath + id.ToString() + "/", Settings.GetContentType, Settings.GetMethodGet, Settings.GetTimeoutResponse).GetResponse();
                if (((HttpWebResponse)httpWebRequest).StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpWebRequest.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        return JsonConvert.DeserializeObject<ActorModel>(result);
                    }
                }
                else {
                    throw new Exception(((HttpWebResponse)httpWebRequest).StatusCode.ToString());
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    throw new Exception("The item does not exist or path error.", ex);
                }
                else
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Update(int id, ActorModel newObj)
        {
            try
            {
                var httpWebRequest = db.CreateWebRequest(db.moviesDbScheme.ActorsPath + id.ToString() + "/", Settings.GetContentType, Settings.GetMethodPut, Settings.GetTimeoutResponse);
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = JsonConvert.SerializeObject(newObj);

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                return ((HttpWebResponse)httpWebRequest.GetResponse()).StatusCode.ToString();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    throw new Exception("The item does not exist or path error.", ex);
                }
                else
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
