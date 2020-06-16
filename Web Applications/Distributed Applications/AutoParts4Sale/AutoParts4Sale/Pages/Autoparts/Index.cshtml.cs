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
    public class IndexModel : PageModel
    {
        private readonly AutoParts4Sale.Data.AutoParts4SaleDbContexts _context;

        public IndexModel(AutoParts4Sale.Data.AutoParts4SaleDbContexts context)
        {
            _context = context;
        }

        public IList<Autopart> Autopart { get;set; }

        public async Task OnGetAsync()
        {
            Autopart = await _context.Autoparts.ToListAsync();
        }
    }
}
