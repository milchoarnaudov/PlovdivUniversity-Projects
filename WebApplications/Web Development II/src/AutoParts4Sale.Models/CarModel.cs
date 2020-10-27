namespace AutoParts4Sale.Core
{
    using System.ComponentModel.DataAnnotations;

    public class CarModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int CarMakeId { get; set; }

        public CarMake CarMake { get; set; }
    }
}
