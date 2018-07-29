using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClient.Interafeces
{
    public interface ICrud<T>
    {
        string Create(T obj);
        List<T> ReadAll ();
        T ReadById(int id);
        string Update(int id);
        string Delete(int id);
    }
}
