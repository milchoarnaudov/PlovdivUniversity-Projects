namespace AutoParts4Sale.Data.Repositories
{
    using AutoParts4Sale.Data;
    using AutoParts4Sale.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CarMakeRepository : IRepository<CarMake, int>
    {
        private readonly ApplicationDbContext _context;

        public CarMakeRepository(ApplicationDbContext context)
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
