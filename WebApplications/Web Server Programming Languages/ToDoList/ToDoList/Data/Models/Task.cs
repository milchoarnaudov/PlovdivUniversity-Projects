using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Data.Models
{
    public class Task
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? Date { get; set; }
    }
}
