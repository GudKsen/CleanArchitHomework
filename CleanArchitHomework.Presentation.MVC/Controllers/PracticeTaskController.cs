using CleanArchitHomework.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CleanArchitHomework.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNet.Identity;

namespace CleanArchitHomework.Presentation.MVC.Controllers
{
    public class PracticeTaskController : Controller
    {
        private readonly IPractiseTasksService _tasksService;

        public PracticeTaskController(IPractiseTasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet]
        public IActionResult TaskInfo(Guid id)
        {
            if (id != null)
            {
                var task = _tasksService.SearchByID(id);
                if (task != null)
                {
                    return View(task);
                }
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTask(PractiseTask task)
        {
            ModelState.Remove("Author");
            if (ModelState.IsValid)
            {
                _tasksService.AddTask(task);
                //_tasksService.Save();
                return RedirectToAction("Index", "TaskCatalog");
            }
            else
            {
                string textarea = String.Empty;
                foreach (var item in ModelState)
                {
                    if (item.Value.ValidationState == ModelValidationState.Invalid)
                    {
                        textarea += item.Key;
                        foreach (var erorr in item.Value.Errors)
                        {
                            textarea += "---";
                            textarea += erorr.ErrorMessage;
                        }
                    }

                }
                return BadRequest(textarea);
            }
        }

        [HttpGet]
        public IActionResult UpdateTask(Guid id)
        {
            if (id != null)
            {
                var task = _tasksService.SearchByID(id);
                if (task != null)
                {
                    return View(task);
                }
                else return NotFound();
            }
            else return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateTask(PractiseTask taskClass)
        {
            if (taskClass != null)
            {
                _tasksService.UpdateTask(taskClass);
                return RedirectToAction("Index", "TaskCatalog");
            }
            else return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteTask(Guid id)
        {
            if (id != null)
            {
                var task = _tasksService.SearchByID(id);
                if (task != null)
                {
                    _tasksService.DeleteByID(id);
                    return RedirectToAction("Index", "TaskCatalog");
                }
                else return NotFound();
            }
            else return NotFound();
        }
    }
}
