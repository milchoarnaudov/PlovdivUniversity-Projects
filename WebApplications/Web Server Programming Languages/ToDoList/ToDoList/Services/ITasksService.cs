using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Services.Dto;

namespace ToDoList.Services
{
    public interface ITasksService
    {
        IEnumerable<TaskDto> GetAll();
    }
}
