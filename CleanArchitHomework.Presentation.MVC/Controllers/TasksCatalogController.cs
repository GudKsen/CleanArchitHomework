using CleanArchitHomework.Application.Interfaces;
using CleanArchitHomework.Application.ViewModels;
using CleanArchitHomework.Domain.Models;
using CleanArchitHomework.Presentation.MVC.Models;
using CleanArchitHomework.Presentation.MVC.Models.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitHomework.Presentation.MVC.Controllers
{

    [Authorize]
    public class TasksCatalogController : Controller
    {
        private readonly ITasksService _tasksService;

        public TasksCatalogController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }


        
        public ActionResult Index(string name, int page = 1, SortState sortState = SortState.NameAsc)
        {
            const int pageSize = 12;
            ViewTasksModel viewTasks = _tasksService.GetViewTasks();

            if (!string.IsNullOrEmpty(name))
            {
                viewTasks.Tasks = viewTasks.Tasks.Where(t => t.Name == name);
            }

            viewTasks.Tasks = sortState switch
            {
                SortState.NameDesc => viewTasks.Tasks.OrderByDescending(c => c.Name),
                SortState.NameAsc => viewTasks.Tasks.OrderBy(c => c.Name),
                SortState.DeadlineDesc => viewTasks.Tasks.OrderByDescending(c => c.Deadline),
                SortState.DeadlineAsc => viewTasks.Tasks.OrderBy(c => c.Deadline),
                _ => viewTasks.Tasks.OrderBy(c => c.Deadline)
            };

            if (viewTasks != null)
            {
                var count = viewTasks.Tasks.Count();
                var items = viewTasks.Tasks.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                TasksViewModel tasksViewModel = new TasksViewModel(viewTasks.Tasks,
                    new SortViewModel(sortState),
                    new FilterViewModel(items, name),
                    new PaginationViewModel(count, page, pageSize));
                return View(tasksViewModel);
            }
            else
            {
                return View(null);
            }
        }
    }
}
