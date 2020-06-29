using AutoParts4Sale.Core;
using AutoParts4Sale.Data;
using AutoParts4Sale.Services.Contracts;
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

        public List<CarMake> GetAll()
        {
            var query = from r in _context.CarMakes select r;
            return query.ToList();
        }

        public CarMake GetById(int id)
        {
            CarMake carMake = _context.CarMakes.FirstOrDefault(m => m.Id == id);

            return carMake;
        }
        public List<CarModel> GetAllByCarMakeId(int carMakeId)
        {
            CarMake carMake = GetById(carMakeId);
            List<CarModel> carModels = carMake.CarModels.ToList();
            return carModels;
        }
        public void PopulateDb()
        {
            CarMake audi = new CarMake
            {
                Name = "Audi",
                CarModels = new List<CarModel>
                {
                    new CarModel
                    {
                        Name = "A3"
                    },
                    new CarModel
                    {
                        Name = "A4"
                    },
                    new CarModel
                    {
                        Name = "A5"
                    },
                    new CarModel
                    {
                        Name = "A6"
                    },
                    new CarModel
                    {
                        Name = "A7"
                    },
                    new CarModel
                    {
                        Name = "A8"
                    }
                }
            };

            CarMake bmw = new CarMake
            {
                Name = "BMW",
                CarModels = new List<CarModel>
                {
                    new CarModel
                    {
                        Name = "3 Series"
                    },
                    new CarModel
                    {
                        Name = "5 Series"
                    },
                    new CarModel
                    {
                        Name = "7 Series"
                    },
                    new CarModel
                    {
                        Name = "8 Series"
                    }
                }
            };

            CarMake mercedes = new CarMake
            {
                Name = "Mercedes",
                CarModels = new List<CarModel>
                {
                    new CarModel
                    {
                        Name = "G class"
                    },
                    new CarModel
                    {
                        Name = "S class"
                    },
                    new CarModel
                    {
                        Name = "C class"
                    },
                    new CarModel
                    {
                        Name = "A class"
                    }
                }
            };

            _context.CarMakes.Add(audi);
            _context.CarMakes.Add(bmw);
            _context.CarMakes.Add(mercedes);
            _context.SaveChanges();
        }
    }
}
