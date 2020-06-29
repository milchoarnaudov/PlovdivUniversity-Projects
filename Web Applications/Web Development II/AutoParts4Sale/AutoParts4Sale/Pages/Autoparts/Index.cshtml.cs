using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoParts4Sale.Core;
using AutoParts4Sale.Data;
using AutoParts4Sale.Services.Implementation;

namespace AutoParts4Sale
{
    public class IndexModel : PageModel
    {
        private readonly AutopartService autopartService;

        public IndexModel(AutoParts4SaleDbContexts context)
        {
            autopartService = new AutopartService(context);
        }

        public IList<Autopart> Autoparts { get;set; }

        public void OnGet()
        {
            Autoparts = autopartService.GetAll();
        }
    }
}
