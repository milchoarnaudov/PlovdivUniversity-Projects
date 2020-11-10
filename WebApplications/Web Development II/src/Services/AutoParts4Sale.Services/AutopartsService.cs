namespace AutoParts4Sale.Services
{
    using AutoParts4Sale.Data.Models;
    using AutoParts4Sale.Data.Repositories;
    using AutoParts4Sale.DTO;
    using AutoParts4Sale.DTO.Autoparts;
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
