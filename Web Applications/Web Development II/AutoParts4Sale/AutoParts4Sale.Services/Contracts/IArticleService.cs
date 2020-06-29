using AutoParts4Sale.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts4Sale.Services.Contracts
{
    interface IArticleService
    {
        List<Article> GetAll();
        Article GetById(int id);
        Article Update(Article updatedArticle);
        Article Add(Article article);
        Article Delete(int id);
    }
}
