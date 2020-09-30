using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoParts4Sale.Core
{
    public class CarModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Car Model")]
        public string Name { get; set; }
        public int CarMakeId { get; set; }
        public CarMake CarMake { get; set; }
    }
}
