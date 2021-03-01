using JobSearch.Domain.Entities.Base;
using System.Collections.Generic;

namespace JobSearch.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public virtual ICollection<UserJob> UserJobs { get; set; }
    }
}
