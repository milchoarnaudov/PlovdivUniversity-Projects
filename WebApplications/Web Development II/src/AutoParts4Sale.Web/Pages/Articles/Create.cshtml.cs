using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoParts4Sale.Core;
using AutoParts4Sale.Data;

namespace AutoParts4Sale.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly ArticleRepository articleService;


        public CreateModel(AutoParts4SaleDbContext context)
        {
            articleService = new ArticleRepository(context);
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Article Article { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            articleService.Add(Article);
            return RedirectToPage("./Index");
        }
    }
}
