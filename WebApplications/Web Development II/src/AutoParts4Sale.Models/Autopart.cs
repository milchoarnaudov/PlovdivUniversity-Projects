namespace AutoParts4Sale.Core
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Autopart
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int CarMakeId { get; set; }

        public CarMake CarMake{ get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
