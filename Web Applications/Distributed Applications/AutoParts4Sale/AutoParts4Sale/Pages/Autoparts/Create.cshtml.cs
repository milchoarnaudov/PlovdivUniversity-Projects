using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoParts4Sale.Core;
using AutoParts4Sale.Data;

namespace AutoParts4Sale
{
    public class CreateModel : PageModel
    {
        private readonly AutoParts4Sale.Data.AutoParts4SaleDbContexts _context;

        public CreateModel(AutoParts4Sale.Data.AutoParts4SaleDbContexts context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Autopart Autopart { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Autoparts.Add(Autopart);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
