using AutoParts4Sale.Core;
using AutoParts4Sale.Data;
using AutoParts4Sale.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoParts4Sale.Repository.Implementation
{
    public class CarMakeRepository : IRepository<CarMake>
    {
        private readonly AutoParts4SaleDbContext _context;

        public CarMakeRepository(AutoParts4SaleDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CarMake> GetAll()
        {
            return _context.CarMakes.Include(cm => cm.CarModels);
        }

        public CarMake GetById(int id)
        {
            CarMake carMake = _context.CarMakes.Find(id);

            return carMake;
        }

        public CarMake Update(CarMake updatedCarMake)
        {
            var carMake = _context.CarMakes.Attach(updatedCarMake);
            carMake.State = EntityState.Modified;
            _context.SaveChanges();

            return updatedCarMake;
        }

        public CarMake Add(CarMake carMake)
        {
            if (carMake != null)
            {
                _context.CarMakes.Add(carMake);
                _context.SaveChanges();
            }

            return carMake;
        }

        public CarMake Delete(int id)
        {
            var carMake = GetById(id);

            if (carMake != null)
            {
                _context.CarMakes.Remove(carMake);
                _context.SaveChanges();
            }

            return carMake;
        }
    }
}
