using JobSearch.Domain.Entities.Base;

namespace JobSearch.Domain.Entities
{
    public class UserJob : EntityBase
    {
        public int UserId { get; set; }
        public int JobId { get; set; }
        public bool IsBookMark { get; set; } = false;
        public bool IsApply { get; set; } = false;

        public virtual User User { get; set; }
        public virtual Job Job { get; set; }
    }
}
