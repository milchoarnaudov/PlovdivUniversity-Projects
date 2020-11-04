namespace AutoParts4Sale.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoParts4Sale.Data;
    using AutoParts4Sale.Data.Models;

    public class AutopartRepository : IRepository<Autopart, int>
    {
        private readonly AutoParts4SaleDbContext _context;

        public AutopartRepository(AutoParts4SaleDbContext context)
        {
            _context = context;
        }

        public Autopart Delete(int id)
        {
            Autopart autopart = GetById(id);

            if (autopart != null)
            {
                _context.Autoparts.Remove(autopart);
                _context.SaveChanges();
            }
            return autopart;
        }

        public IEnumerable<Autopart> GetAll()
        {
            return _context.Autoparts.AsEnumerable();
        }

        public Autopart GetById(int id)
        {
            Autopart autopart = _context.Autoparts.Find(id);

            return autopart;
        }

        public Autopart Update(int id)
        {
            // TODO

            return null;
        }

        public bool AutopartExists(int id)
        {
            return _context.Autoparts.Any(e => e.Id == id);
        }

        public Autopart Add(Autopart autopart)
        {
            if (autopart != null)
            {
                _context.Autoparts.Add(autopart);
                _context.SaveChanges();
            }

            return autopart;
        }
    }
}
