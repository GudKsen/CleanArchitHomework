using CleanArchitHomework.Domain.Models;
using CleanArchitHomework.Presentation.MVC.Models.Operations;

namespace CleanArchitHomework.Presentation.MVC.Models
{
    public class IndexViewModel
    {
        public IEnumerable<TaskClass> Tasks { get; }
        public SortViewModel Sort { get; }
        public FilterViewModel Filter { get; }
        public PaginationViewModel Pagination { get; }

        public IndexViewModel(IEnumerable<TaskClass> tasks, SortViewModel sortViewModel, FilterViewModel filterViewModel, PaginationViewModel paginationViewModel)
        {
            Tasks = tasks;
            Sort = sortViewModel;
            Filter = filterViewModel;
            Pagination = paginationViewModel;
        }
    }
}
