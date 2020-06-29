﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoParts4Sale.Core;
using AutoParts4Sale.Data;
using AutoParts4Sale.Services.Implementation;

namespace AutoParts4Sale.Pages.Articles
{
    public class DetailsModel : PageModel
    {
        private readonly ArticleService articleService;

        public DetailsModel(AutoParts4SaleDbContexts context)
        {
            articleService = new ArticleService(context);
        }

        public Article Article { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int _id = (int)id;

            Article = articleService.GetById(_id);

            if (Article == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
