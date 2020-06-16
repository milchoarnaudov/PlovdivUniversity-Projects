using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoParts4Sale.Core;
using AutoParts4Sale.Data;

namespace AutoParts4Sale
{
    public class EditModel : PageModel
    {
        private readonly AutoParts4Sale.Data.AutoParts4SaleDbContexts _context;

        public EditModel(AutoParts4Sale.Data.AutoParts4SaleDbContexts context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Autopart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutopartExists(Autopart.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AutopartExists(int id)
        {
            return _context.Autoparts.Any(e => e.Id == id);
        }
    }
}
