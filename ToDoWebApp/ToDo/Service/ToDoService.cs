using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Service
{
    public class ToDoService : IToDoService
    {
        public IToDoRepository toDoRepository;

        public ToDoService(IToDoRepository toDoRepository) 
        {
            this.toDoRepository = toDoRepository;
        }

        public Task AddTask(string description)
        {
            return toDoRepository.AddTask(description);
        }

        public void DeleteTask(int Id)
        {
            toDoRepository.DeleteTask(Id);
        }

        public List<Task> GetTasks()
        {
            return toDoRepository.GetTasks();
        }

        public Task ToggleComplete(int Id)
        {
            return toDoRepository.ToggleComplete(Id);
        }
    }
}
