using JobSearch.Domain.Enums;

namespace JobSearch.Application.ViewModel.Jobs
{
    public class GetJobResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public Category Category { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsBookMark { get; set; }
        public bool IsApply { get; set; }
    }
}
