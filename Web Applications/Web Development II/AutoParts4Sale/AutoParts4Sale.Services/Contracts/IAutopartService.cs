using AutoParts4Sale.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts4Sale.Services.Contracts
{
    interface IAutopartService
    {
        List<Autopart> GetAll();
        Autopart GetById(int id);
        Autopart Update(Autopart updatedAutopart);
        Autopart Add(Autopart autopart, int carMakeId, int carModelId, int categoryId);
        Autopart Delete(int id);
    }
}
