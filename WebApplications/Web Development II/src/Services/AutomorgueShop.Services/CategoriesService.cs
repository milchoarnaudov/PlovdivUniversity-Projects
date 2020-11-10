namespace AutomorgueShop.Services
{
    using AutomorgueShop.Data.Repositories;
    using AutomorgueShop.DTO;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoriesService : ICategoriesService
    {
        private readonly CategoryRepository categoryRepository;

        public CategoriesService(CategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return categoryRepository.GetAll().Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name
            }).AsEnumerable(); ;
        }
    }
}
