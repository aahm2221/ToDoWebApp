using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo
{
    public interface IToDoRepository
    {
        List<Task> GetTasks();
        Task ToggleComplete(int Id);
        void DeleteTask(int Id);
        Task AddTask(string description);
    }
}
