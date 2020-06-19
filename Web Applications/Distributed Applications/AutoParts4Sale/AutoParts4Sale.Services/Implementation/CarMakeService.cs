using AutoParts4Sale.Core;
using AutoParts4Sale.Data;
using AutoParts4Sale.Services.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace AutoParts4Sale.Services.Implementation
{
    public class CarMakeService : ICarMakeService
    {
        private readonly AutoParts4SaleDbContexts _context;

        public CarMakeService(AutoParts4SaleDbContexts context)
        {
            _context = context;
        }

        public CarMake Add(CarMake car)
        {
            return new CarMake();
        }

        public List<CarMake> GetAll()
        {
            var query = from r in _context.CarMakes select r;
            return query.ToList();
        }

        public CarMake GetById(int id)
        {
            return new CarMake();
        }

        public CarMake Update(CarMake updatedCarMake)
        {
            return new CarMake();
        }
    }
}
