using CleanArchitHomework.Domain.Enums;

namespace CleanArchitHomework.Presentation.MVC.Models.TaskModels
{
    public class TaskViewModel : TaskViewModelBase
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override string Grade { get; set; }
        public override DateTime Deadline { get; set; }
    }
}
