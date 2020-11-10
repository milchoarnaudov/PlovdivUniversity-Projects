namespace AutomorgueShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CarMake
    {
        public CarMake()
        {
            CarModels = new HashSet<CarModel>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<CarModel> CarModels { get; set; }
    }
}
