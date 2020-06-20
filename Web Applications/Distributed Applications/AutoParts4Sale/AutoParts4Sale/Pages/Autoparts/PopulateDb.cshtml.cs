using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoParts4Sale.Data;
using AutoParts4Sale.Services.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoParts4Sale.Pages.Autoparts
{
    public class PopulateDbModel : PageModel
    {
        private readonly CarMakeService carMakeService;
        private readonly CategoryService categoryService;

        public PopulateDbModel(AutoParts4SaleDbContexts context)
        {
            this.carMakeService = new CarMakeService(context);
            this.categoryService = new CategoryService(context);
        }

        public void OnGet()
        {
            categoryService.PopulateDb();
            carMakeService.PopulateDb();
        }
    }
}