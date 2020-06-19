using AutoParts4Sale.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts4Sale.Services.Contracts
{
    interface IAutopart
    {
        IEnumerable<Autopart> GetAutopartsByName(string name);
        Autopart GetById(int id);
        Autopart Update(Autopart updatedAutopart);
        Autopart Add(Autopart autopart);
        Autopart Delete(int id);
        int Commit();
    }
}
