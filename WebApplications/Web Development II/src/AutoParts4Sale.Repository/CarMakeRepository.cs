
namespace AutoParts4Sale.Repository.Implementation
{
    using AutoParts4Sale.Core;
    using AutoParts4Sale.Data;
    using System.Collections.Generic;
    using System.Linq;

    public class CarMakeRepository : IRepository<CarMake, int>
    {
        private readonly AutoParts4SaleDbContext _context;

        public CarMakeRepository(AutoParts4SaleDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CarMake> GetAll()
        {
            return _context.CarMakes.AsEnumerable();
        }

        public CarMake GetById(int id)
        {
            CarMake carMake = _context.CarMakes.Find(id);

            return carMake;
        }

        public CarMake Update(int id)
        {
            // TODO

            return null;
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
