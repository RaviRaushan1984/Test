using System.Collections.Generic;

namespace ContactManagement_DAL.Generic
{
    /// <summary>
    /// Generic class which contains generic methods is common across DataAccessLayer.
    /// </summary>
    /// <typeparam name="T">Object on which operation would perform</typeparam>
    public abstract class GenericClass<T>
    {
        public abstract List<T> Select(T obj);

        public abstract void Insert(ref T obj);

        public abstract void Update(ref T obj);

        public abstract void Delete(ref T obj);
    }
}
