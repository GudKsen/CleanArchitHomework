using CleanArchitHomework.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CleanArchitHomework.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNet.Identity;

namespace CleanArchitHomework.Presentation.MVC.Controllers
{
   
    public class TaskController : Controller
    {
        private readonly ITasksService _tasksService;

        public TaskController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet]
        public IActionResult TaskInfo(Guid id)
        {
            if (id!= null)
            {
                var task = _tasksService.SearchByID(id);
                if (task != null)
                {
					//ViewData["TaskClass"] = task;
					//ViewData["Comments"] = task.taskClass.Comments;
					return View(task.taskClass);
                }
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult CreateTask() 
        {
            var task = new TaskClass();
            return View(task);
        }

        [HttpPost]
        public IActionResult CreateTask(TaskClass task)
        {
            task.Author = User.Identity.GetUserId();
            ModelState.Remove("Author");
            if (ModelState.IsValid)
            {
                
                _tasksService.AddTask(task);
                //_tasksService.Save();
                return RedirectToAction("Index", "TasksCatalog");
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

        public ActionResult AddResource()
        {
            return PartialView("CreateResourcePart", new Resource());
        }

        [HttpGet]
        public IActionResult UpdateTask(Guid id)
        {
            if (id != null)
            {
                var task = _tasksService.SearchByID(id);
                if (task != null)
                {
                    return View(task.taskClass);
                }
                else return NotFound();
            }
            else return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateTask(TaskClass taskClass)
        {
            if (taskClass != null)
            {
                _tasksService.UpdateTask(taskClass);
                return RedirectToAction("Index", "TasksCatalog");
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
                    return RedirectToAction("Index", "TasksCatalog");
                }
                else return NotFound();
            }
            else return NotFound();
        }

    }
}
