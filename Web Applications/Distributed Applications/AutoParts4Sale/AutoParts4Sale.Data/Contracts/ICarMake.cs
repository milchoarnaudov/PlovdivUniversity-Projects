using AutoParts4Sale.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts4Sale.Services.Contracts
{
    interface ICarMake
    {
        IEnumerable<CarMake> GetCarsByName(string name);
        CarMake GetById(int id);
        CarMake Update(CarMake updatedCary);
        CarMake Add(CarMake car);
        CarMake Delete(int id);
        int Commit();
    }
}
