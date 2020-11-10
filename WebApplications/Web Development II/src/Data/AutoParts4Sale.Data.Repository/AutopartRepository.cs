namespace AutomorgueShop.Data.Repositories
{
    using System.Linq;
    using AutomorgueShop.Data;
    using AutomorgueShop.Data.Models;

    public class AutopartRepository : Repository, IRepository<Autopart, int>
    {
        public AutopartRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public Autopart Delete(int id)
        {
            Autopart autopart = GetById(id);

            if (autopart != null)
            {
                dbContext.Autoparts.Remove(autopart);
            }

            return autopart;
        }

        public IQueryable<Autopart> GetAll()
        {
            return dbContext.Autoparts;
        }

        public Autopart GetById(int id)
        {
            return dbContext.Autoparts.FirstOrDefault(x => x.Id == id);
        }

        public Autopart Update(Autopart autopart)
        {
            return dbContext.Update(autopart).Entity;
        }

        public Autopart Add(Autopart autopart)
        {
            if (autopart != null)
            {
                dbContext.Autoparts.Add(autopart);
            }

            return autopart;
        }
    }
}
