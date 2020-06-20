using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoParts4Sale.Core;
using AutoParts4Sale.Data;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using AutoParts4Sale.Services.Implementation;

namespace AutoParts4Sale
{
    public class CreateModel : PageModel
    {
        private readonly AutopartService autopartService;
        private readonly CarMakeService carMakeService;
        private readonly CategoryService categoryService;

        [BindProperty]
        public Autopart Autopart { get; set; }

        [BindProperty]
        public int CarMakeId { get; set; }
        [BindProperty]
        public int CarModelId { get; set; }
        [BindProperty]
        public int CategoryId { get; set; }

        public SelectList CarMakes { get; set; }
        public SelectList CarModels { get; set; }
        public SelectList Categories { get; set; }

        public CreateModel(AutoParts4SaleDbContexts context)
        {
            carMakeService = new CarMakeService(context);
            autopartService = new AutopartService(context);
            categoryService = new CategoryService(context);
        }

        public IActionResult OnGet()
        {
            CarMakes = new SelectList(carMakeService.GetAll(), nameof(CarMake.Id), nameof(CarMake.Name));
            Categories = new SelectList(categoryService.GetAll(), nameof(CarMake.Id), nameof(CarMake.Name));
            //CarModels = new SelectList(carMakeService.GetById(CarMakeId).CarModels, nameof(CarMake.Id), nameof(CarMake.Name));
            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            autopartService.Add(Autopart, CarMakeId, CarModelId, CategoryId);

            return RedirectToPage("./Index");
        }
    }
}
