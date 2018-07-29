using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClient.Interafeces
{
    interface ICrud<T>
    {
        string Create(T obj);
        List<T> ReadAll ();
        T ReadById(string id);
        string Update(string key);
        string Delete(string key);
    }
}
