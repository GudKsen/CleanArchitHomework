using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace CleanArchitHomework.Presentation.MVC.Models.Operations
{
    public class SortViewModel
    {
        public SortViewModel(SortState sortState) 
        {
            DeadlineSort = sortState == SortState.DeadlineAsc ? SortState.DeadlineDesc : SortState.DeadlineAsc;
            NameSort = sortState == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            Current = sortState;
        }

        public SortState DeadlineSort { get; }
        public SortState NameSort { get; }
        public SortState Current { get; }
    }
}
