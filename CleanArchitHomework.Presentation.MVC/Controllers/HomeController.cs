using Microsoft.AspNetCore.Mvc;
using CleanArchitHomework.Application.Interfaces;
using CleanArchitHomework.Presentation.MVC.Models;
using CleanArchitHomework.Domain.Models;
using CleanArchitHomework.Presentation.MVC.Models.Operations;
using CleanArchitHomework.Application.ViewModels;

namespace CleanArchitHomework.Presentation.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITasksService _tasksService;

        public HomeController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        //public ActionResult Index()
        //{
        //    var viewTasks = _tasksService.GetViewTasks();
        //    return View();
        //}

        public ActionResult Index()
        {
           
           return View();
        }

        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login()
        //{
        //    return RedirectToAction("Index");
        //}
    }
}
