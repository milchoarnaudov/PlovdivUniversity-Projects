using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoParts4Sale.Core
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Autopart> Autoparts { get; set; }
    }
}
