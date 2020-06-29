using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoParts4Sale.Core
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
    }
}
