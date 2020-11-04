namespace AutoParts4Sale.Data.Repositories
{
    using AutoParts4Sale.Data;
    using AutoParts4Sale.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryRepository : IRepository<Category, int>
    {
        private readonly AutoParts4SaleDbContext _context;

        public CategoryRepository(AutoParts4SaleDbContext context)
        {
            _context = context;
        }

        public Category Add(Category category)
        {
            if(category != null)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }

            return category;
        }

        public Category Delete(int id)
        {
            var category = GetById(id);

            if(category != null)
            {
                _context.Remove(category);
                _context.SaveChanges();
            }

            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.AsEnumerable();
        }

        public Category GetById(int id)
        {
            Category category = _context.Categories.FirstOrDefault(m => m.Id == id);

            return category;
        }

        public Category Update(int id)
        {
            //TODO

            return null;
        }
    }
}
