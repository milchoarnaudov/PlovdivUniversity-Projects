using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoParts4Sale.Core;
using AutoParts4Sale.Data;
using AutoParts4Sale.Data.Repositories;

namespace AutoParts4Sale
{
    public class IndexModel : PageModel
    {
        private readonly AutopartRepository autopartService;

        public IndexModel(AutoParts4SaleDbContext context)
        {
            autopartService = new AutopartRepository(context);
        }

        public IEnumerable<Autopart> Autoparts { get;set; }

        public void OnGet()
        {
            Autoparts = autopartService.GetAll();
        }
    }
}
