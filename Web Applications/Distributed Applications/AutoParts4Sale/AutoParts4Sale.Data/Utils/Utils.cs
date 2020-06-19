using AutoParts4Sale.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts4Sale.Data.Utils
{
    public class Utils
    {
        public static List<CarMake> InMemoryCarMakes()
        {
            List<CarMake> carMakes = new List<CarMake>
            {
                new CarMake
                {
                    Name = "Audi"
                },
                new CarMake
                {
                Name = "Audi"
                }
            };
            return carMakes;
        }
    }
}
