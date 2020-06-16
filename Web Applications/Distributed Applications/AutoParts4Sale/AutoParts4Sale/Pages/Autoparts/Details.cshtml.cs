using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoParts4Sale.Core;
using AutoParts4Sale.Data;

namespace AutoParts4Sale
{
    public class DetailsModel : PageModel
    {
        private readonly AutoParts4Sale.Data.AutoParts4SaleDbContexts _context;

        public DetailsModel(AutoParts4Sale.Data.AutoParts4SaleDbContexts context)
        {
            _context = context;
        }

        public Autopart Autopart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Autopart = await _context.Autoparts.FirstOrDefaultAsync(m => m.Id == id);

            if (Autopart == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
