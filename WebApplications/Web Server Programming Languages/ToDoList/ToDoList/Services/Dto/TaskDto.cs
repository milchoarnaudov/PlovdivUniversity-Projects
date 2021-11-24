using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Services.Dto
{
    public class TaskDto
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? Date { get; set; }
    }
}
