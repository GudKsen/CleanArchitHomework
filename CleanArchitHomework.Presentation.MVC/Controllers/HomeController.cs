﻿using Microsoft.AspNetCore.Mvc;
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
                SortState.IdDesc => viewTasks.Tasks.OrderByDescending(c => c.ID),
                SortState.IdAsc => viewTasks.Tasks.OrderBy(c => c.ID),
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
