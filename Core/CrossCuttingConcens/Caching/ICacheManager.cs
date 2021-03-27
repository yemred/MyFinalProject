using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcens.Caching
{
    public interface ICacheManager
    {
        //Generic Version Get
        T Get<T>(string key);
        
        //Generic Olmayan version Get
        object Get(string key);
        void Add(string key, object value, int duration);

        //Cache de var mı ?  Kontrol
        bool IsAdd(string key);

        //Cache den silme
        void Remove(string key);

        void RemoveByPattern(string patter);
    }
}
