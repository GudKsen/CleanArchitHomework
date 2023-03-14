using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace CleanArchitHomework.Presentation.MVC.Models.Operations
{
    public class SortViewModel
    {
        public SortViewModel(SortState sortState) 
        {
            IdSort = sortState == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
            NameSort = sortState == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            Current = sortState;
        }

        public SortState IdSort { get; }
        public SortState NameSort { get; }
        public SortState Current { get; }
    }
}
