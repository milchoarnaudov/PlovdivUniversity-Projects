namespace AutomorgueShop.Data.Repositories
{
    using AutomorgueShop.Data;
    using AutomorgueShop.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryRepository : IRepository<Category, int>
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public Category Add(Category category)
        {
            if(category != null)
            {
                dbContext.Categories.Add(category);
            }

            return category;
        }

        public Category Delete(int id)
        {
            var category = GetById(id);

            if(category != null)
            {
                dbContext.Remove(category);
            }

            return category;
        }

        public IQueryable<Category> GetAll()
        {
            return dbContext.Categories;
        }

        public Category GetById(int id)
        {
            return dbContext.Categories.FirstOrDefault(x => x.Id == id);
        }

        public Category Update(Category category)
        {
            return dbContext.Update(category).Entity;
        }
    }
}
