namespace AutoParts4Sale.Web.Controllers
{
    using AutoParts4Sale.Services;
    using Microsoft.AspNetCore.Mvc;
    using AutoParts4Sale.Web.ViewModels.Autoparts;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using AutoParts4Sale.DTO;

    public class AutopartsController : Controller
    {
        private readonly IAutopartsService autopartsService;
        private readonly IMakesService makesService;
        private readonly ICategoriesService categoriesService;

        public AutopartsController(IAutopartsService autopartsService, IMakesService makesService, ICategoriesService categoryService)
        {
            this.autopartsService = autopartsService;
            this.makesService = makesService;
            this.categoriesService = categoryService;
        }

        public IActionResult All()
        {
            var viewModelList = autopartsService.GetAll().Select(x => new DetailedAutopartViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Make = x.Make,
                Model = x.Model,
                DateAdded = x.DateAdded,
                ModifiedDate = x.ModifiedDate
            }).ToList();


            return View(viewModelList);
        }

        public IActionResult GetModels(int id)
        {
            var viewModelList = makesService.GetAll().Select(x => new MakeViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Models = x.Models.Select(m => new ModelViewModel
                {
                    Id = m.Id,
                    Name = m.Name
                })
            });

            var result = viewModelList.FirstOrDefault(x => x.Id == id).Models;

            return Json(result);
        }

        public IActionResult Create()
        {
            var viewModel = new CreateAutopartViewModel
            {
                Makes = makesService.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                Categories = categoriesService.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateAutopartInputModel input)
        {
            var autopartDto = new CreateAutopartDTO
            {
                Name = input.Name,
                Price = input.Price,
                CategoryId = input.CategoryId,
                MakeId = input.MakeId,
                ModelId = input.ModelId
            };

            autopartsService.Create(autopartDto);
            return RedirectToAction("All");
        }
    }
}
