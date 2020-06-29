using AutoParts4Sale.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts4Sale.Services.Contracts
{
    interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
    }
}
