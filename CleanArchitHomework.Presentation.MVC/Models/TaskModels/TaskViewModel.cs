using CleanArchitHomework.Domain.Enums;

namespace CleanArchitHomework.Presentation.MVC.Models.TaskModels
{
    public class TaskViewModel 
    {
        public  int ID { get; set; }
        public  string Name { get; set; }
        public  string Description { get; set; }
        public  string Grade { get; set; }
        public  DateTime Deadline { get; set; }
    }
}
