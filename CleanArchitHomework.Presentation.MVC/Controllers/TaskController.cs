using CleanArchitHomework.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CleanArchitHomework.Domain.Models;

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
        public IActionResult GetTask(Guid id)
        {
            if (id!= null)
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
        public IActionResult CreateTask(TaskClass task)
        {
            if (task != null)
            {
                _tasksService.AddTask(task);
                //_tasksService.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return BadRequest();
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
        public IActionResult DeleteTask(Guid id)
        {
            if (id != null)
            {
                var task = _tasksService.SearchByID(id);
                if (task != null)
                {
                    _tasksService.DeleteByID(id);
                    return RedirectToAction("Index", "Home");
                }
                else return NotFound();
            }
            else return NotFound();
        }

    }
}
