namespace AutoParts4Sale.Data.Repositories
{
    using AutoParts4Sale.Data;
    using AutoParts4Sale.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CarModelRepository : IRepository<CarModel, int>
    {
        private readonly ApplicationDbContext dbContext;

        public CarModelRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public CarModel Add(CarModel carModel)
        {
            if(carModel != null)
            {
                dbContext.CarModels.Add(carModel);
            }

            return carModel;
        }

        public CarModel Delete(int id)
        {
            var carModel = GetById(id);

            if(carModel != null)
            {
                dbContext.CarModels.Remove(carModel);
            }

            return carModel;
        }

        public IQueryable<CarModel> GetAll()
        {
            return dbContext.CarModels;
        }

        public CarModel GetById(int id)
        {
            return dbContext.CarModels.FirstOrDefault(x => x.Id == id);
        }

        public CarModel Update(CarModel carModel)
        {
            return dbContext.Update(carModel).Entity;
        }
    }
}
