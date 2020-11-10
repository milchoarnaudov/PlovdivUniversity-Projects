namespace AutoParts4Sale.Services
{
    using AutoParts4Sale.Data.Repositories;
    using AutoParts4Sale.DTO;
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
