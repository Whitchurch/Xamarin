using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace practice.Interfaces
{
    public interface ISQLUtility<T>
        where T:class
    {
        Task <List<T>> GetItems();
        Task<T> GetItem(string race);
        void SaveItem();
        void DeleteItem(T item);

    }
}
