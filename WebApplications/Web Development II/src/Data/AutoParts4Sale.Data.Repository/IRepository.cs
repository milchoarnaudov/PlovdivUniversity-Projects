namespace AutoParts4Sale.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    public interface IRepository<T, PKType>
    {
        IQueryable<T> GetAll();
        T GetById(PKType id);
        T Update(T updatedItem);
        T Add(T item);
        T Delete(int id);
    }
}
