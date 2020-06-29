using AutoParts4Sale.Core;
using AutoParts4Sale.Data;
using AutoParts4Sale.Services.Contracts;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace AutoParts4Sale.Services.Implementation
{
    public class AutopartService : IAutopartService
    {
        private readonly AutoParts4SaleDbContexts _context;

        public AutopartService(AutoParts4SaleDbContexts context)
        {
            _context = context;
        }

        public Autopart Add(Autopart autopart, int carMakeId, int carModelId, int categoryId)
        {
            if(autopart != null)
            {
                CarMake carMake = _context.CarMakes.Find(carMakeId);
                CarModel carModel = _context.CarModels.Find(carModelId);
                Category category = _context.Categories.Find(categoryId);

                autopart.CarMake = carMake;
                autopart.CarModel = carModel;
                autopart.Category = category;

                _context.Autoparts.Add(autopart);
                _context.SaveChanges();
            }

            return autopart;
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

        public List<Autopart> GetAll()
        {
            var query = from r in _context.Autoparts select r;
            return query.ToList();
        }

        public Autopart GetById(int id)
        {
            Autopart autopart = _context.Autoparts.FirstOrDefault(m => m.Id == id);

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
    }
}
