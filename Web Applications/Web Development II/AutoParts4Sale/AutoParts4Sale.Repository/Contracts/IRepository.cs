using System.Collections.Generic;

namespace AutoParts4Sale.Repository.Contracts
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Update(T updatedItem);
        T Add(T item);
        T Delete(int id);
    }
}
