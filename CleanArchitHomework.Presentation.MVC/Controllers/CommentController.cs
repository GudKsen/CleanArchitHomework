using CleanArchitHomework.Application.Interfaces;
using CleanArchitHomework.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitHomework.Presentation.MVC.Controllers
{
	public class CommentController : Controller
	{
		private readonly ITasksService _tasksService;
		public CommentController(ITasksService tasksService)
		{
			_tasksService = tasksService;
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Guid Id, string Author, string Content)
		{
			ModelState.Remove("Date");
			if (ModelState.IsValid)
			{
				var task = _tasksService.SearchByID(Id);
				if (task != null)
				{
					if (task.taskClass.Comments != null)
					{
						Comment c = new Comment
						{
							Author = Author,
							Content = Content,
							Date = DateTime.Now
						};
						var t = task.taskClass.Comments.ToList();
						t.Add(c);
						task.taskClass.Comments = t;
						_tasksService.UpdateTask(task.taskClass);
						return RedirectToAction("TaskInfo", "Task", new {Id} );
					}
					else
					{
						task.taskClass.Comments = new List<Comment>();
						Comment c = new Comment
						{
							Author = Author,
							Content = Content,
							Date = DateTime.Now
						};
						var t = task.taskClass.Comments.ToList();
						t.Add(c);
						task.taskClass.Comments = t;
						_tasksService.UpdateTask(task.taskClass);
						return RedirectToAction("TaskInfo", "Task", new { Id } );
					}
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
