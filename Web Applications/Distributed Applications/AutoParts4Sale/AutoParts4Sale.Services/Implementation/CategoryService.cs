using AutoParts4Sale.Core;
using AutoParts4Sale.Data;
using AutoParts4Sale.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AutoParts4Sale.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly AutoParts4SaleDbContexts _context;

        public CategoryService(AutoParts4SaleDbContexts context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            var query = from r in _context.Categories select r;
            return query.ToList();
        }
        public Category GetById(int id)
        {
            Category category = _context.Categories.FirstOrDefault(m => m.Id == id);

            return category;
        }
        public void PopulateDb()
        {
            Category brakeSystem = new Category
            {
                Name = "Break System"
            };

            Category engine = new Category
            {
                Name = "Engine"
            };

            Category damping = new Category
            {
                Name = "Damping"
            };

            Category exhaustSystem = new Category
            {
                Name = "Exhaust System"
            };

            _context.Categories.Add(brakeSystem);
            _context.Categories.Add(engine);
            _context.Categories.Add(damping);
            _context.Categories.Add(exhaustSystem);
            _context.SaveChanges();
        }

        
    }
}
