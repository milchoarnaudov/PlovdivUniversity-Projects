namespace AutoParts4Sale.Data
{
    using AutoParts4Sale.Data.Models;
    using System.Collections.Generic;

    public class Seed
    {
        public List<Category> GetInitialCategoriesValues()
        {
            List<Category> categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Break System"
                },
                new Category
                {
                    Id = 2,
                    Name = "Engine"
                },
                new Category
                {
                    Id = 3,
                    Name = "Damping"
                },
                new Category
                {
                    Id = 4,
                    Name = "Exhaust System"
                },
            };

            return categories;
        }

        public List<CarMake> GetInitialCarMakesValues()
        {
            List<CarMake> carMakes = new List<CarMake>
            {
                new CarMake
                {
                    Id = 1,
                    Name = "Audi"
                },
                new CarMake
                {
                    Id = 2,
                    Name = "BMW"
                },
                new CarMake
                {
                    Id = 3,
                    Name = "Mercedes"
                },
            };

            return carMakes;
        }

        public List<CarModel> GetInitialCarModelsValues()
        {
            var carModels = new List<CarModel>
                {
                    new CarModel
                    {
                        Id = 1,
                        Name = "A3",
                        CarMakeId = 1
                    },
                    new CarModel
                    {
                        Id = 2,
                        Name = "A4",
                        CarMakeId = 1
                    },
                    new CarModel
                    {
                        Id = 3,
                        Name = "A5",
                        CarMakeId = 1
                    },
                    new CarModel
                    {
                        Id = 4,
                        Name = "A6",
                        CarMakeId = 1
                    },
                    new CarModel
                    {
                        Id = 5,
                        Name = "A7",
                        CarMakeId = 1
                    },
                    new CarModel
                    {
                        Id = 6,
                        Name = "A8",
                        CarMakeId = 1
                    },
                    new CarModel
                    {
                        Id = 7,
                        Name = "3 Series",
                        CarMakeId = 2
                    },
                    new CarModel
                    {
                        Id = 8,
                        Name = "5 Series",
                        CarMakeId = 2
                    },
                    new CarModel
                    {
                        Id = 9,
                        Name = "7 Series",
                        CarMakeId = 2
                    },
                    new CarModel
                    {
                        Id = 10,
                        Name = "8 Series",
                        CarMakeId = 2
                    },
                    new CarModel
                    {
                        Id = 11,
                        Name = "G class",
                        CarMakeId = 3
                    },
                    new CarModel
                    {
                        Id = 12,
                        Name = "S class",
                        CarMakeId = 3
                    },
                    new CarModel
                    {
                        Id = 13,
                        Name = "C class",
                        CarMakeId = 3
                    },
                    new CarModel
                    {
                        Id = 14,
                        Name = "A class",
                        CarMakeId = 3
                    },
                    new CarModel
                    {
                        Id = 15,
                        Name = "E class",
                        CarMakeId = 3
                    }
                };

            return carModels;
        }
    }
}
