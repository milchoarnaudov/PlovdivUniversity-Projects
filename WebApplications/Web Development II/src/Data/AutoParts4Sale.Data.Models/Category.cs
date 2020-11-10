namespace AutomorgueShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.Autoparts = new HashSet<Autopart>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Autopart> Autoparts { get; set; }
    }
}
