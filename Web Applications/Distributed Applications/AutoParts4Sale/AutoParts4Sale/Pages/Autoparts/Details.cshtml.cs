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
    public class DetailsModel : PageModel
    {
        private readonly AutopartService autopartService;
        public Autopart Autopart { get; set; }
        public DetailsModel(AutoParts4SaleDbContexts context)
        {
            autopartService = new AutopartService(context);
        }


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
    }
}
