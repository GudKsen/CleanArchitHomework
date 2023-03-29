using CleanArchitHomework.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitHomework.Presentation.MVC.Controllers
{
    public class ResourceController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskClass model, string Name, string Url)
        {
            //ModelState.Remove("Date");
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    model.Resources ??= new List<Resource>();
                    Resource c = new Resource
                    {
                        Name = Name,
                        UrlResource = Url
                    };
                    var t = model.Resources.ToList();
                    t.Add(c);
                    model.Resources = t;
                    return RedirectToAction("CreateTask", "Task", new { task = model });
                }
                else
                {
                    return BadRequest();
                }
            }
            return View();
        }
    }
}
