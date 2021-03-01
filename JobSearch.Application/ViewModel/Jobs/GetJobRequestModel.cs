using JobSearch.Application.ViewModel.Pagings;
using JobSearch.Domain.Enums;

namespace JobSearch.Application.ViewModel.Jobs
{
    public class GetJobRequestModel : PagingRequestModel
    {
        public string Title { get; set; }
        public string City { get; set; }
        public EmploymentType? EmploymentType { get; set; }
        public Category? Category { get; set; }
        public bool? IsSort { get; set; }
    }
}
