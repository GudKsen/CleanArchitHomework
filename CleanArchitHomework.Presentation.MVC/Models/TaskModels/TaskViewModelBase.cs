namespace CleanArchitHomework.Presentation.MVC.Models.TaskModels
{
    public  class TaskViewModelBase
    {
        public  int Id { get; set; }
        public  string Name { get; set; }
        public  string Description { get; set; }
        public  string Grade { get; set; }
        public  DateTime Deadline { get; set; }
    }
}
