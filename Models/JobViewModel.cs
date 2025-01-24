using System.ComponentModel.DataAnnotations;

namespace ISMT23CWeb.Models
{
    public class JobViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Salary is required!")]
        public decimal Salary { get; set; }
        public int AddedById { get; set; }

        // for displaying id in order list

        public int DisplayOrder { get; set; }
    }

    public class PaginatedJobViewModel
    {
        public int CurrentPage { get; set; } =1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public List<JobViewModel> Data { get; set; }
    }
}