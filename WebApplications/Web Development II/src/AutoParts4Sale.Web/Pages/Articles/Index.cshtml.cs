using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoParts4Sale.Core;
using AutoParts4Sale.Data;
using AutoParts4Sale.Data.Repositories;

namespace AutoParts4Sale.Pages.Articles
{
    public class IndexModel : PageModel
    {
        private readonly ArticleRepository articleService;
        public IndexModel(AutoParts4SaleDbContext context)
        {
            articleService = new ArticleRepository(context);
        }

        public IEnumerable<Article> Articles { get;set; }

        public void OnGet()
        {
            Articles = articleService.GetAll();
        }
    }
}
