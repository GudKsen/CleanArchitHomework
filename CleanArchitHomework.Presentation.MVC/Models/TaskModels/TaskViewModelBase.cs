namespace CleanArchitHomework.Presentation.MVC.Models.TaskModels
{
    public abstract class TaskViewModelBase
    {
        public abstract int Id { get; set; }
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        public abstract string Grade { get; set; }
        public abstract DateTime Deadline { get; set; }
    }
}
