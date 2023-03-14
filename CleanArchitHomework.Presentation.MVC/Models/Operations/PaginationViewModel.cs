namespace CleanArchitHomework.Presentation.MVC.Models.Operations
{
    public class PaginationViewModel
    {
        public PaginationViewModel(int count, int pageNumber, int pageSize) 
        {
            PageNumber = pageNumber;
            TotalPages = (int) Math.Ceiling(count / (decimal)pageSize);
        }

        public int PageNumber { get; set; }
        public int TotalPages { get; set; }

        public bool HasPreviousPage => PageNumber > 0;
        public bool HasNextPage => PageNumber < TotalPages;
    }
}
