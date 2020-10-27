namespace AutoParts4Sale.Repository.Implementation
{
    using AutoParts4Sale.Core;
    using AutoParts4Sale.Data;
    using System.Collections.Generic;
    using System.Linq;

    public class CarModelRepository : IRepository<CarModel, int>
    {
        private readonly AutoParts4SaleDbContext _context;

        public CarModelRepository(AutoParts4SaleDbContext context)
        {
            _context = context;
        }

        public CarModel Add(CarModel carModel)
        {
            if(carModel != null)
            {
                _context.CarModels.Add(carModel);
                _context.SaveChanges();
            }

            return carModel;
        }

        public CarModel Delete(int id)
        {
            var carModel = GetById(id);

            if(carModel != null)
            {
                _context.CarModels.Remove(carModel);
                _context.SaveChanges();
            }

            return carModel;
        }

        public IEnumerable<CarModel> GetAll()
        {
            return _context.CarModels.AsEnumerable(); ;
        }

        public CarModel GetById(int id)
        {
            CarModel carModel = _context.CarModels.Find(id);

            return carModel;
        }

        public CarModel Update(int id)
        {
            //TODO

            return null;
        }
    }
}
