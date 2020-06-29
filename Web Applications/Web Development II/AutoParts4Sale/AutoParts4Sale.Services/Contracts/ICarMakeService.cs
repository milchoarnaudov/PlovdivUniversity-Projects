using AutoParts4Sale.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts4Sale.Services.Contracts
{
    interface ICarMakeService
    {
        List<CarMake> GetAll();
        CarMake GetById(int id);

    }
}
