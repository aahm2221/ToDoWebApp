using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Service;

namespace ToDo.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IToDoService toDoService;

        public List<Task> Tasks { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IToDoService toDoService)
        {
            _logger = logger;
            this.toDoService = toDoService;
        }

        public void OnGet()
        {
            Tasks = toDoService.GetTasks();
        }

        public IActionResult OnPostDeleteTask(int id)
        {
            toDoService.DeleteTask(id);

            return RedirectToPage();
        }

        public IActionResult OnGetToggleComplete(int id)
        {
            toDoService.ToggleComplete(id);

            return RedirectToPage();
        }

        public IActionResult OnPostAddTask(string description)
        {
            toDoService.AddTask(description);

            return RedirectToPage();
        }
    }
}