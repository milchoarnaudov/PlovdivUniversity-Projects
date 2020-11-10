namespace AutomorgueShop.Services
{
    using AutomorgueShop.Data.Models;
    using AutomorgueShop.Data.Repositories;
    using AutomorgueShop.DTO;
    using AutomorgueShop.DTO.Autoparts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AutopartsService : IAutopartsService
    {
        private readonly AutopartRepository autopartRepository;
        private readonly CategoryRepository categoryRepository;

        public AutopartsService(AutopartRepository repo, CategoryRepository categoryRepository)
        {
            autopartRepository = repo;
            this.categoryRepository = categoryRepository;
        }

        public void Create(CreateAutopartDTO autopart)
        {
            if (autopart == null)
            {
                return;
            }

            var autopartEntity = new Autopart
            {
                Name = autopart.Name,
                CarModelId = autopart.ModelId,
                CategoryId = autopart.CategoryId,
                DateAdded = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                Price = autopart.Price
            };

            autopartRepository.Add(autopartEntity);
            autopartRepository.SaveChanges();
        }

        public IEnumerable<AutopartDTO> GetAll()
        {
            return autopartRepository.GetAll().Select(x => new AutopartDTO
            {
                Id = x.Id,
                Name = x.Name,
                Make = x.CarModel.CarMake.Name,
                Model = x.CarModel.Name,
                DateAdded = x.DateAdded,
                ModifiedDate = x.ModifiedDate
            }).AsEnumerable();
        }
    }
}
