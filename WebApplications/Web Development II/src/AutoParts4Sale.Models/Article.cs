namespace AutoParts4Sale.Core
{
    using System.ComponentModel.DataAnnotations;

    public class Article
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
