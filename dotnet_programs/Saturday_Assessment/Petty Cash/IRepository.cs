using System.Collections.Generic;
namespace PettyCash
{
        public interface IRepository<T>
    {
        void Add(T item);
        List<T> GetAll();
    }
}
