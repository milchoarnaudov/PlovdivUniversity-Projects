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
using AutoParts4Sale.Services.Implementation;

namespace AutoParts4Sale
{
    public class EditModel : PageModel
    {
        private readonly AutoParts4SaleDbContexts _context;
        private readonly AutopartService autopartService;

        public EditModel(AutoParts4SaleDbContexts context)
        {
            autopartService = new AutopartService(context);
            _context = context;
        }

        [BindProperty]
        public Autopart Autopart { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int _id = (int)id;

            Autopart = autopartService.GetById(_id);

            if (Autopart == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            autopartService.Update(Autopart);

            try
            {
               _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (!autopartService.AutopartExists(Autopart.Id))
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

        
    }
}
