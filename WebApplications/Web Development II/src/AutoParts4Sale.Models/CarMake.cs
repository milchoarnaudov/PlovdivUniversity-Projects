namespace AutoParts4Sale.Core
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CarMake
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<CarModel> CarModels { get; set; }
    }
}
