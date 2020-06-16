using AutoParts4Sale.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts4Sale.Services.Contracts
{
    interface ICarModel
    {
        IEnumerable<CarModel> GetModelsCarsByName(string name);
        CarModel GetById(int id);
        CarModel Update(CarModel updatedModelCar);
        CarModel Add(CarModel modelCar);
        CarModel Delete(int id);
        int Commit();
    }
}
