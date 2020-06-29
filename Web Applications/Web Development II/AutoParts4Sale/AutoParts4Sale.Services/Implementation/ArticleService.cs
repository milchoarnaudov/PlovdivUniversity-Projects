using AutoParts4Sale.Core;
using AutoParts4Sale.Data;
using AutoParts4Sale.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AutoParts4Sale.Services.Implementation
{
    public class ArticleService : IArticleService
    {
        AutoParts4SaleDbContexts _context;
        public ArticleService(AutoParts4SaleDbContexts context)
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

        public List<Article> GetAll()
        {
            var query = from r in _context.Articles select r;
            return query.ToList();
        }

        public Article GetById(int id)
        {
            Article article = _context.Articles.FirstOrDefault(a => a.Id == id);

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
