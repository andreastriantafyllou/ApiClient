using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ApiClient.Modules
{
    class SharedCrudController
    {
        HttpHelper httpHelper;
        public SharedCrudController()
        {
            httpHelper = new HttpHelper();
        }

        public string Create(object obj, string path)
        {
            var httpWebRequest = httpHelper.CreateWebRequest(path, Settings.GetContentType, Settings.GetMethodPost, Settings.GetTimeoutResponse);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(obj);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            return ((HttpWebResponse)httpWebRequest.GetResponse()).StatusCode.ToString();
        }

        public string Delete(int id, string path)
        {
            try
            {
                var httpWebRequest = httpHelper.CreateWebRequest(path, null, Settings.GetMethodDelete, Settings.GetTimeoutResponse);
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

        public string ReadAll(string path)
        {
            var httpWebRequest = httpHelper.CreateWebRequest(path, Settings.GetContentType, Settings.GetMethodGet, Settings.GetTimeoutResponse).GetResponse();
            if (((HttpWebResponse)httpWebRequest).StatusCode == HttpStatusCode.OK)
            {
                using (var streamReader = new StreamReader(httpWebRequest.GetResponseStream()))
                {
                    return streamReader.ReadToEnd();
                }
            }
            else
            {
                throw new Exception(((HttpWebResponse)httpWebRequest).StatusCode.ToString());
            }
        }

        public string ReadById(int id, string path)
        {
            try
            {
                var httpWebRequest = httpHelper.CreateWebRequest(path, Settings.GetContentType, Settings.GetMethodGet, Settings.GetTimeoutResponse).GetResponse();
                if (((HttpWebResponse)httpWebRequest).StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpWebRequest.GetResponseStream()))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
                else
                {
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

        public string Update(int id, object newObj, string path)
        {
            try
            {
                var httpWebRequest = httpHelper.CreateWebRequest(path, Settings.GetContentType, Settings.GetMethodPut, Settings.GetTimeoutResponse);
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
