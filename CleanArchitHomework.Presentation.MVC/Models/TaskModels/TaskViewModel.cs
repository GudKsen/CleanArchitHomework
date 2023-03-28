using CleanArchitHomework.Domain.Enums;
using CleanArchitHomework.Domain.Models;

namespace CleanArchitHomework.Presentation.MVC.Models.TaskModels
{
    public class TaskViewModel 
    {
        public  int ID { get; set; }
        public  string Name { get; set; }
        public  string Description { get; set; }
        public  string Grade { get; set; }
        public string Author { get; set; }
        public  DateTime Deadline { get; set; }
        public DateTime PublishDate { get; set; }
        public IEnumerable<Resource> Resources { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
