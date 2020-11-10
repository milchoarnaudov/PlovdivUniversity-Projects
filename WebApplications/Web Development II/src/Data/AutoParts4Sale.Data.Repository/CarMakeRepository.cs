namespace AutoParts4Sale.Data.Repositories
{
    using AutoParts4Sale.Data;
    using AutoParts4Sale.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CarMakeRepository : IRepository<CarMake, int>
    {
        private readonly ApplicationDbContext dbContext;

        public CarMakeRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IQueryable<CarMake> GetAll()
        {
            return dbContext.CarMakes;
        }

        public CarMake GetById(int id)
        {
            return dbContext.CarMakes.FirstOrDefault(x => x.Id == id);
        }

        public CarMake Update(CarMake carMake)
        {
            return dbContext.Update(carMake).Entity;
        }

        public CarMake Add(CarMake carMake)
        {
            if (carMake != null)
            {
                dbContext.CarMakes.Add(carMake);
            }

            return carMake;
        }

        public CarMake Delete(int id)
        {
            var carMake = GetById(id);

            if (carMake != null)
            {
                dbContext.CarMakes.Remove(carMake);
            }

            return carMake;
        }
    }
}
