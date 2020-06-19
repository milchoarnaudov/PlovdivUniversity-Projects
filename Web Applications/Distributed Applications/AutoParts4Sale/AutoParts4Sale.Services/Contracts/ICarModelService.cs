using AutoParts4Sale.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts4Sale.Services.Contracts
{
    interface ICarModelService
    {
        List<CarModel> GetAll();
        CarModel GetById(int id);
        CarModel Update(CarModel updatedModelCar);
        CarModel Add(CarModel modelCar);
        CarModel Delete(int id);
        int Commit();
    }
}
