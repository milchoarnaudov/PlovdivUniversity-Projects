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
using AutoParts4Sale.Repository.Implementation;

namespace AutoParts4Sale
{
    public class CreateModel : PageModel
    {
        private readonly AutopartRepository autopartRepository;
        private readonly CarMakeRepository carMakeRepository;
        private readonly CategoryRepository categoryRepository;
        private readonly CarModelRepository carModelRepository;

        [BindProperty]
        public Autopart Autopart { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CarMakeId { get; set; }
        [BindProperty]
        public int CarModelId { get; set; }
        [BindProperty]
        public int CategoryId { get; set; }

        public SelectList CarMakes { get; set; }
        public SelectList CarModels { get; set; }
        public SelectList Categories { get; set; }

        public CreateModel(AutoParts4SaleDbContext context)
        {
            carMakeRepository = new CarMakeRepository(context);
            autopartRepository = new AutopartRepository(context);
            categoryRepository = new CategoryRepository(context);
            carModelRepository = new CarModelRepository(context);
        }

        public IActionResult OnGet()
        {
            CarMakes = new SelectList(carMakeRepository.GetAll(), nameof(CarMake.Id), nameof(CarMake.Name));
            Categories = new SelectList(categoryRepository.GetAll(), nameof(Category.Id), nameof(Category.Name));
            CarModels = new SelectList(carModelRepository.GetAll().Where(cm => cm.CarMakeId == CarMakeId), nameof(CarModel.Id), nameof(CarModel.Name));
           
            return Page();
        }

        public JsonResult OnGetSubCategories()
        {
            return new JsonResult(carModelRepository.GetAll().Where(cm => cm.CarMakeId == CarMakeId));
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Autopart != null)
            {
                CarMake carMake = carMakeRepository.GetById(CarMakeId);
                Category category = categoryRepository.GetById(CategoryId);

                Autopart.CarMake = carMake;
                Autopart.Category = category;
            }

            autopartRepository.Add(Autopart);

            return RedirectToPage("./Index");
        }
    }
}
