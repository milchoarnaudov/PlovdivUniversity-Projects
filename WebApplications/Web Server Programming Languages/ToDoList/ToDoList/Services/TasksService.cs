using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Services.Dto;

namespace ToDoList.Services
{
    public class TasksService : ITasksService
    {
        private readonly ApplicationDbContext dbContext;

        public TasksService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<TaskDto> GetAll() =>
            dbContext.Tasks.Select(t => new TaskDto
            {
                Title = t.Title,
                Content = t.Content,
                Date = t.Date
            });
    }
}
