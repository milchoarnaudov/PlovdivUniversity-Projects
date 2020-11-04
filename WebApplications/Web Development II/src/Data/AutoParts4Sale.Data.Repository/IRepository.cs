namespace AutoParts4Sale.Data.Repositories
{
    using System.Collections.Generic;

    public interface IRepository<T, PKType>
    {
        IEnumerable<T> GetAll();
        T GetById(PKType id);
        T Update(PKType updatedItem);
        T Add(T item);
        T Delete(int id);
    }
}
