using CleanArchitHomework.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchitHomework.Presentation.MVC.Models.Operations
{
    public class FilterViewModel
    {
        public FilterViewModel(List<TaskClass> taskClasses, string name) 
        { 
            Tasks = new SelectList(taskClasses, "ID", "Name");
            SelectedTask = name;
        }

        public SelectList Tasks { get; }

        public string SelectedTask { get; }

    }
}
