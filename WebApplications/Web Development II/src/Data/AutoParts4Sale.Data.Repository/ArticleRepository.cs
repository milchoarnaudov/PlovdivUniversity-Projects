namespace AutoParts4Sale.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoParts4Sale.Data;
    using AutoParts4Sale.Data.Models;

    public class ArticleRepository : IRepository<Article, int>
    {
        ApplicationDbContext _context;

        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Article Add(Article article)
        {
            if(article != null)
            {
                _context.Articles.Add(article);
                _context.SaveChanges();
            }

            return article;
        }

        public Article Delete(int id)
        {
            Article article = GetById(id);

            if(article != null)
            {
                _context.Articles.Remove(article);
                _context.SaveChanges();
            }

            return article;
        }

        public IEnumerable<Article> GetAll()
        {
            return _context.Articles.AsEnumerable();
        }

        public Article GetById(int id)
        {
            Article article = _context.Articles.Find(id);

            return article;
        }

        public Article Update(int id)
        {
            // TODO
            return null;
        }
    }
}
