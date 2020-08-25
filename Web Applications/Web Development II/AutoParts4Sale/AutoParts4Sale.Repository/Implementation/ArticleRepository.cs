using AutoParts4Sale.Core;
using AutoParts4Sale.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoParts4Sale.Repository.Contracts;

namespace AutoParts4Sale.Repository.Implementation
{
    public class ArticleRepository : IRepository<Article>
    {
        AutoParts4SaleDbContext _context;

        public ArticleRepository(AutoParts4SaleDbContext context)
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
            return _context.Articles;
        }

        public Article GetById(int id)
        {
            Article article = _context.Articles.Find(id);

            return article;
        }

        public Article Update(Article updatedArticle)
        {
            var article = _context.Articles.Attach(updatedArticle);
            article.State = EntityState.Modified;
            _context.SaveChanges();

            return updatedArticle;
        }
    }
}
