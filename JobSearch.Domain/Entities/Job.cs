using JobSearch.Domain.Entities.Base;
using JobSearch.Domain.Enums;
using System.Collections.Generic;

namespace JobSearch.Domain.Entities
{
    public class Job : EntityBase
    {
        public string Title { get; set; }
        public string Photo { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public Category Category { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual ICollection<UserJob> UserJobs { get; set; }
    }
}
