using AutoParts4Sale.Core;
using AutoParts4Sale.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoParts4Sale.Repository.Contracts;

namespace AutoParts4Sale.Repository.Implementation
{
    public class AutopartRepository : IRepository<Autopart>
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
            return _context.Autoparts;
        }

        public Autopart GetById(int id)
        {
            Autopart autopart = _context.Autoparts.Find(id);

            return autopart;
        }

        public Autopart Update(Autopart updatedAutopart)
        {
            var entity = _context.Autoparts.Attach(updatedAutopart);
            entity.State = EntityState.Modified;
            _context.SaveChanges();

            return updatedAutopart;
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
