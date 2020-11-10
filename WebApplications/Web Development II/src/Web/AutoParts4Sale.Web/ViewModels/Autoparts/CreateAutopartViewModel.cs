namespace AutomorgueShop.Web.ViewModels.Autoparts
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class CreateAutopartViewModel
    {
        public IEnumerable<SelectListItem> Makes { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
