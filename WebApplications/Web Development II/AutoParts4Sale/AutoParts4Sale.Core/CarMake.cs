using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoParts4Sale.Core
{
    public class CarMake
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Car Make")]
        public string Name { get; set; }
        public List<CarModel> CarModels { get; set; }
    }
}
